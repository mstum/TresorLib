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
    internal class TresorCharacterClasses
    {
        internal static readonly char[] Lowercase = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        internal static readonly char[] Uppercase = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        internal static readonly char[] Numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        internal static readonly char[] Space = new char[] { ' ' };
        internal static readonly char[] Dashes = new char[] { '-', '_' };
        internal static readonly char[] Symbols = new char[] { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '{', '|', '}', '~', '-', '_' };

        internal static readonly char[] All;

        static TresorCharacterClasses()
        {
            All = new char[Lowercase.Length + Uppercase.Length + Numbers.Length + Space.Length + Symbols.Length];

            var counter = 0;
            foreach (var arr in new char[][] { Lowercase, Uppercase, Numbers, Space, Symbols })
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    All[counter] = arr[i];
                    counter++;
                }
            }
        }
    }

    internal class TresorImpl
    {
        private string _phrase;
        private int _length;
        private int _repeat;
        private List<char> _allowed;
        private List<List<char>> _required;

        private static List<Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<char[]>>> Accessors =
            new List<Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<char[]>>>
                {
                    new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<char[]>>(config => config.LowercaseLetters, () => TresorCharacterClasses.Lowercase),
                    new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<char[]>>(config => config.UppercaseLetters, () => TresorCharacterClasses.Uppercase),
                    new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<char[]>>(config => config.Numbers, () => TresorCharacterClasses.Numbers),
                    new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<char[]>>(config => config.Space, () => TresorCharacterClasses.Space),
                    new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<char[]>>(config => config.Dash, () => TresorCharacterClasses.Dashes),
                    new Tuple<Func<TresorConfig, TresorConfig.AllowedMode>, Func<char[]>>(config => config.Symbols, () => TresorCharacterClasses.Symbols)
                };

        internal TresorImpl(TresorConfig config, string passphrase)
        {
            _phrase = passphrase ?? string.Empty;
            _length = config.PasswordLength;
            _repeat = config.MaxRepetition;

            var allowed = TresorCharacterClasses.All.CopyList();

            var required = new List<List<char>>();

            foreach (var acc in Accessors)
            {
                var mode = acc.Item1(config);
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
            if (charset == null || charset.Count == 0)
            {
                return;
            }
            if (allowed == null)
            {
                allowed = _allowed;
            }

            for (int i = 0, n = charset.Count; i < n; i++)
            {
                var index = allowed.IndexOf(charset[i]);
                if (index >= 0)
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
            if (_required.Count > _length)
            {
                throw new InvalidOperationException("Length too small to fit all required characters");
            }
            if (_allowed.Count == 0)
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

            while (result.Length < _length)
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
