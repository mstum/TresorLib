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

namespace TresorLib
{
    internal static class ByteToBits
    {
        internal static void ToBits(this byte b, IList<int> targetList)
        {
            switch (b)
            {
                case 0x00: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x01: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x02: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x03: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x04: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x05: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x06: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x07: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x08: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x09: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x0A: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x0B: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x0C: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x0D: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x0E: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x0F: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x10: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x11: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x12: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x13: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x14: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x15: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x16: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x17: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x18: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x19: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x1A: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x1B: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x1C: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x1D: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x1E: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x1F: targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x20: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x21: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x22: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x23: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x24: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x25: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x26: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x27: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x28: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x29: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x2A: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x2B: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x2C: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x2D: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x2E: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x2F: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x30: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x31: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x32: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x33: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x34: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x35: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x36: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x37: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x38: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x39: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x3A: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x3B: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x3C: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x3D: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x3E: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x3F: targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x40: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x41: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x42: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x43: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x44: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x45: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x46: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x47: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x48: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x49: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x4A: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x4B: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x4C: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x4D: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x4E: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x4F: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x50: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x51: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x52: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x53: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x54: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x55: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x56: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x57: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x58: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x59: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x5A: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x5B: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x5C: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x5D: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x5E: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x5F: targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x60: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x61: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x62: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x63: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x64: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x65: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x66: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x67: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x68: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x69: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x6A: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x6B: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x6C: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x6D: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x6E: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x6F: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x70: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x71: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x72: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x73: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x74: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x75: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x76: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x77: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x78: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x79: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x7A: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x7B: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x7C: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x7D: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x7E: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x7F: targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x80: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x81: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x82: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x83: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x84: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x85: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x86: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x87: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x88: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x89: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x8A: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x8B: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x8C: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x8D: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x8E: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x8F: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x90: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x91: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x92: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x93: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x94: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x95: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x96: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x97: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0x98: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0x99: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0x9A: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0x9B: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0x9C: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0x9D: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0x9E: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0x9F: targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xA0: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xA1: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xA2: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xA3: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xA4: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xA5: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xA6: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xA7: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xA8: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xA9: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xAA: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xAB: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xAC: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xAD: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xAE: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xAF: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xB0: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xB1: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xB2: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xB3: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xB4: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xB5: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xB6: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xB7: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xB8: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xB9: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xBA: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xBB: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xBC: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xBD: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xBE: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xBF: targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xC0: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xC1: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xC2: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xC3: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xC4: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xC5: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xC6: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xC7: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xC8: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xC9: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xCA: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xCB: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xCC: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xCD: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xCE: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xCF: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xD0: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xD1: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xD2: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xD3: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xD4: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xD5: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xD6: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xD7: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xD8: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xD9: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xDA: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xDB: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xDC: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xDD: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xDE: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xDF: targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xE0: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xE1: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xE2: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xE3: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xE4: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xE5: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xE6: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xE7: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xE8: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xE9: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xEA: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xEB: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xEC: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xED: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xEE: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xEF: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xF0: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xF1: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xF2: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xF3: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xF4: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xF5: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xF6: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xF7: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                case 0xF8: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(0); break;
                case 0xF9: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); targetList.Add(1); break;
                case 0xFA: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(0); break;
                case 0xFB: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); targetList.Add(1); break;
                case 0xFC: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(0); break;
                case 0xFD: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); targetList.Add(1); break;
                case 0xFE: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(0); break;
                case 0xFF: targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); targetList.Add(1); break;
                default: throw new ArgumentOutOfRangeException(nameof(b), "Invalid Byte: " + b);
            }           
        }
    }
}
