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
using System.Security.Cryptography;
using System.Text;

namespace TresorLib
{
    /// <summary>
    /// Generate uniformly distributed output in any base from a bit stream
    /// http://checkmyworking.com/2012/06/converting-a-stream-of-binary-digits-to-a-stream-of-base-n-digits/
    /// </summary>
    internal class TresorStream
    {
        private readonly string _phrase;
        private readonly string _service;
        private readonly int _entropy;
        private IDictionary<int, List<int>> _bases = new Dictionary<int, List<int>>();

        internal TresorStream(string phrase, string service, int entropy)
        {
            _phrase = phrase;
            _service = service;
            _entropy = entropy;

            var hash = CreateHash(phrase, service + Tresor.UUID, 2 * entropy);
            _bases[2] = new List<int>(hash.Length * 8);
            foreach (var hashByte in hash)
            {
                hashByte.ToBits(_bases[2]);
            }
        }

        internal int Generate(int n, int numBase = 2, bool inner = false)
        {
            var value = n;
            var k = (int)Math.Ceiling(Math.Log(n) / Math.Log(numBase));
            var r = (int)(Math.Pow(numBase, k)) - n;
            IList<int> chunk;

            // loop:
            while(value >= n)
            {
                chunk = Shift(numBase, k);
                if(chunk == null)
                {
                    if(inner)
                    {
                        return n;
                    }
                    throw new InvalidOperationException("Chunk was null");
                }

                value = Evaluate(chunk, numBase);
                if(value >= n)
                {
                    if(r == 1)
                    {
                        continue; // loop:
                    }
                    Push(r, value - n);
                    value = Generate(n, r, true);
                }
            }

            return value;

        }

        private IList<int> Shift(int numBase, int k)
        {
            if (!_bases.ContainsKey(numBase) || _bases[numBase].Count < k)
            {
                return null;
            }

            var result = _bases[numBase].Splice(0, k);
            return result;                   
        }

        private void Push(int numBase, int value)
        {
            if (!_bases.ContainsKey(numBase))
            {
                _bases[numBase] = new List<int>();
            }

            _bases[numBase].Add(value);
        }

        private static int Evaluate(IList<int> chunk, int numBase)
        {
            var sum = 0;
            var i = chunk.Count;

            while(i-- > 0)
            {
                sum += chunk[i] * (int)Math.Pow(numBase, chunk.Count - (i + 1));
            }
            return sum;
        }

        private static byte[] CreateHash(string key, string message, int entropy)
        {
            const int iterations = 8;
            var numBytes = entropy / 8.0f;
            var keySize = ((int)Math.Ceiling(numBytes / 4.0f)) * 4;

            var saltBytes = Encoding.UTF8.GetBytes(message);
            var pk = new Rfc2898DeriveBytes(key, saltBytes, iterations);
            byte[] hash = pk.GetBytes(keySize);

            return hash;
        }
    }
}
