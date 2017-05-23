#region LICENSE
/* Copyright (C) 2017 Michael Stum <opensource@stum.de>

Adapted from Vault, copyright (C) 2012-2014 James Coglan - https://github.com/jcoglan/vault

This program is free software: you can redistribute it and/or modify it under the terms of the
GNU General Public License as published by the Free Software Foundation, either version 3 of the
License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.
If not, see http://www.gnu.org/licenses/. */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TresorLib
{
    internal class TresorImpl
    {
        private static readonly char[] _lowercaseChars;
        private static readonly char[] _uppercaseChars;
        private static readonly char[] _numberChars;
        private static readonly char[] _spaceChars;
        private static readonly char[] _dashChars;
        private static readonly char[] _symbolChars;

        private string _phrase;
        private int _length;
        private int _repeat;
        private List<char> _allowed;
        private List<List<char>> _required;

        static TresorImpl()
        {
            _lowercaseChars = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            _uppercaseChars = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            _numberChars = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            _spaceChars = new[] { ' ' };
            _dashChars = new[] { '-', '_' };
            _symbolChars = new[] { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '{', '|', '}', '~' }
                           .Concat(_dashChars)
                           .ToArray();
        }

        internal TresorImpl(TresorConfig config, string passphrase)
        {
            _phrase = passphrase ?? string.Empty;
            _length = config.PasswordLength;
            _repeat = config.MaxRepetition;

            var allowed = _lowercaseChars.Concat(_uppercaseChars).Concat(_numberChars).Concat(_spaceChars).Concat(_symbolChars).CopyList();
            var required = new List<List<char>>();

            var accessors = new List<Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>>
                {
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.LowercaseLetters, () => _lowercaseChars),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.UppercaseLetters, () => _uppercaseChars),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.Numbers, () => _numberChars),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.Space, () => _spaceChars),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.Dash, () => _dashChars),
                    new Tuple<Func<TresorConfig.AllowedMode>, Func<char[]>>(() => config.Symbols, () => _symbolChars)
                };

            foreach (var acc in accessors)
            {
                var mode = acc.Item1();
                if (mode == TresorConfig.AllowedMode.Forbidden)
                {
                    Subtract(acc.Item2(), allowed);
                }
                else if (mode == TresorConfig.AllowedMode.Required)
                {
                    Require(acc.Item2(), config.RequiredCount, required);
                }
            }

            var n = config.PasswordLength - required.Count;
            while (--n >= 0)
            {
                required.Add(allowed.CopyList());
            }

            _required = required;
            _allowed = allowed;
        }

        private void Subtract(IList<char> charset, List<char> allowed)
        {
            if(charset == null || charset.Count == 0)
            {
                return;
            }
            if(allowed == null)
            {
                allowed = _allowed;
            }

            for(int i = 0, n = charset.Count; i < n; i++)
            {
                var index = allowed.IndexOf(charset[i]);
                if(index >= 0)
                {
                    allowed.Splice(index, 1);
                }
            }
        }

        private static void Require(IList<char> charset, int n, List<List<char>> required)
        {
            while (n-- != 0)
            {
                required.Add(charset.CopyList());
            }
        }

        private int Entropy()
        {
            int entropy = 0;
            int n = _required.Count;
            for (var i = 0; i < n; i++)
            {
                entropy += (int)Math.Ceiling(Math.Log(i + 1) / Math.Log(2));
                entropy += (int)Math.Ceiling(Math.Log(_required[i].Count) / Math.Log(2));
            }
            return entropy;
        }
        
        internal string Generate(string service)
        {
            if(_required.Count > _length)
            {
                throw new InvalidOperationException("Length too small to fit all required characters");
            }
            if(_allowed.Count == 0)
            {
                throw new InvalidOperationException("No characters available to create a password");
            }

            var required = CopyRequired();
            var stream = new TresorStream(_phrase, service, Entropy());
            var result = new StringBuilder(_length);

            List<char> charset;
            char? previous;
            int index;
            int i;
            bool same;

            while(result.Length < _length)
            {
                index = stream.Generate(required.Count);
                charset = required.Splice(index, 1)[0];
                previous = result.Length > 0 ? result[result.Length - 1] : (char?)null;
                i = _repeat - 1;
                same = previous.HasValue && i >= 0;

                while (same && (i-- != 0))
                {
                    var sbIndex = result.Length + i - _repeat;
                    same = same && (result[sbIndex] == previous);
                }
                if (same)
                {
                    charset = charset.CopyList();
                    if (previous.HasValue) { charset.RemoveAll(ac => ac == previous); }
                }

                index = stream.Generate(charset.Count);

                result.Append(charset[index]);
            }

            return result.ToString();
        }

        private List<List<char>> CopyRequired()
        {
            return _required.Select(r => r.Select(rq => rq).ToList()).ToList();
        }
    }
}
