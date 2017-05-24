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

namespace TresorLib
{
    internal static class ByteToBits
    {
        internal static string ToBits(this byte b)
        {
            switch (b)
            {
                case 0x00: return "00000000";
                case 0x01: return "00000001";
                case 0x02: return "00000010";
                case 0x03: return "00000011";
                case 0x04: return "00000100";
                case 0x05: return "00000101";
                case 0x06: return "00000110";
                case 0x07: return "00000111";
                case 0x08: return "00001000";
                case 0x09: return "00001001";
                case 0x0A: return "00001010";
                case 0x0B: return "00001011";
                case 0x0C: return "00001100";
                case 0x0D: return "00001101";
                case 0x0E: return "00001110";
                case 0x0F: return "00001111";
                case 0x10: return "00010000";
                case 0x11: return "00010001";
                case 0x12: return "00010010";
                case 0x13: return "00010011";
                case 0x14: return "00010100";
                case 0x15: return "00010101";
                case 0x16: return "00010110";
                case 0x17: return "00010111";
                case 0x18: return "00011000";
                case 0x19: return "00011001";
                case 0x1A: return "00011010";
                case 0x1B: return "00011011";
                case 0x1C: return "00011100";
                case 0x1D: return "00011101";
                case 0x1E: return "00011110";
                case 0x1F: return "00011111";
                case 0x20: return "00100000";
                case 0x21: return "00100001";
                case 0x22: return "00100010";
                case 0x23: return "00100011";
                case 0x24: return "00100100";
                case 0x25: return "00100101";
                case 0x26: return "00100110";
                case 0x27: return "00100111";
                case 0x28: return "00101000";
                case 0x29: return "00101001";
                case 0x2A: return "00101010";
                case 0x2B: return "00101011";
                case 0x2C: return "00101100";
                case 0x2D: return "00101101";
                case 0x2E: return "00101110";
                case 0x2F: return "00101111";
                case 0x30: return "00110000";
                case 0x31: return "00110001";
                case 0x32: return "00110010";
                case 0x33: return "00110011";
                case 0x34: return "00110100";
                case 0x35: return "00110101";
                case 0x36: return "00110110";
                case 0x37: return "00110111";
                case 0x38: return "00111000";
                case 0x39: return "00111001";
                case 0x3A: return "00111010";
                case 0x3B: return "00111011";
                case 0x3C: return "00111100";
                case 0x3D: return "00111101";
                case 0x3E: return "00111110";
                case 0x3F: return "00111111";
                case 0x40: return "01000000";
                case 0x41: return "01000001";
                case 0x42: return "01000010";
                case 0x43: return "01000011";
                case 0x44: return "01000100";
                case 0x45: return "01000101";
                case 0x46: return "01000110";
                case 0x47: return "01000111";
                case 0x48: return "01001000";
                case 0x49: return "01001001";
                case 0x4A: return "01001010";
                case 0x4B: return "01001011";
                case 0x4C: return "01001100";
                case 0x4D: return "01001101";
                case 0x4E: return "01001110";
                case 0x4F: return "01001111";
                case 0x50: return "01010000";
                case 0x51: return "01010001";
                case 0x52: return "01010010";
                case 0x53: return "01010011";
                case 0x54: return "01010100";
                case 0x55: return "01010101";
                case 0x56: return "01010110";
                case 0x57: return "01010111";
                case 0x58: return "01011000";
                case 0x59: return "01011001";
                case 0x5A: return "01011010";
                case 0x5B: return "01011011";
                case 0x5C: return "01011100";
                case 0x5D: return "01011101";
                case 0x5E: return "01011110";
                case 0x5F: return "01011111";
                case 0x60: return "01100000";
                case 0x61: return "01100001";
                case 0x62: return "01100010";
                case 0x63: return "01100011";
                case 0x64: return "01100100";
                case 0x65: return "01100101";
                case 0x66: return "01100110";
                case 0x67: return "01100111";
                case 0x68: return "01101000";
                case 0x69: return "01101001";
                case 0x6A: return "01101010";
                case 0x6B: return "01101011";
                case 0x6C: return "01101100";
                case 0x6D: return "01101101";
                case 0x6E: return "01101110";
                case 0x6F: return "01101111";
                case 0x70: return "01110000";
                case 0x71: return "01110001";
                case 0x72: return "01110010";
                case 0x73: return "01110011";
                case 0x74: return "01110100";
                case 0x75: return "01110101";
                case 0x76: return "01110110";
                case 0x77: return "01110111";
                case 0x78: return "01111000";
                case 0x79: return "01111001";
                case 0x7A: return "01111010";
                case 0x7B: return "01111011";
                case 0x7C: return "01111100";
                case 0x7D: return "01111101";
                case 0x7E: return "01111110";
                case 0x7F: return "01111111";
                case 0x80: return "10000000";
                case 0x81: return "10000001";
                case 0x82: return "10000010";
                case 0x83: return "10000011";
                case 0x84: return "10000100";
                case 0x85: return "10000101";
                case 0x86: return "10000110";
                case 0x87: return "10000111";
                case 0x88: return "10001000";
                case 0x89: return "10001001";
                case 0x8A: return "10001010";
                case 0x8B: return "10001011";
                case 0x8C: return "10001100";
                case 0x8D: return "10001101";
                case 0x8E: return "10001110";
                case 0x8F: return "10001111";
                case 0x90: return "10010000";
                case 0x91: return "10010001";
                case 0x92: return "10010010";
                case 0x93: return "10010011";
                case 0x94: return "10010100";
                case 0x95: return "10010101";
                case 0x96: return "10010110";
                case 0x97: return "10010111";
                case 0x98: return "10011000";
                case 0x99: return "10011001";
                case 0x9A: return "10011010";
                case 0x9B: return "10011011";
                case 0x9C: return "10011100";
                case 0x9D: return "10011101";
                case 0x9E: return "10011110";
                case 0x9F: return "10011111";
                case 0xA0: return "10100000";
                case 0xA1: return "10100001";
                case 0xA2: return "10100010";
                case 0xA3: return "10100011";
                case 0xA4: return "10100100";
                case 0xA5: return "10100101";
                case 0xA6: return "10100110";
                case 0xA7: return "10100111";
                case 0xA8: return "10101000";
                case 0xA9: return "10101001";
                case 0xAA: return "10101010";
                case 0xAB: return "10101011";
                case 0xAC: return "10101100";
                case 0xAD: return "10101101";
                case 0xAE: return "10101110";
                case 0xAF: return "10101111";
                case 0xB0: return "10110000";
                case 0xB1: return "10110001";
                case 0xB2: return "10110010";
                case 0xB3: return "10110011";
                case 0xB4: return "10110100";
                case 0xB5: return "10110101";
                case 0xB6: return "10110110";
                case 0xB7: return "10110111";
                case 0xB8: return "10111000";
                case 0xB9: return "10111001";
                case 0xBA: return "10111010";
                case 0xBB: return "10111011";
                case 0xBC: return "10111100";
                case 0xBD: return "10111101";
                case 0xBE: return "10111110";
                case 0xBF: return "10111111";
                case 0xC0: return "11000000";
                case 0xC1: return "11000001";
                case 0xC2: return "11000010";
                case 0xC3: return "11000011";
                case 0xC4: return "11000100";
                case 0xC5: return "11000101";
                case 0xC6: return "11000110";
                case 0xC7: return "11000111";
                case 0xC8: return "11001000";
                case 0xC9: return "11001001";
                case 0xCA: return "11001010";
                case 0xCB: return "11001011";
                case 0xCC: return "11001100";
                case 0xCD: return "11001101";
                case 0xCE: return "11001110";
                case 0xCF: return "11001111";
                case 0xD0: return "11010000";
                case 0xD1: return "11010001";
                case 0xD2: return "11010010";
                case 0xD3: return "11010011";
                case 0xD4: return "11010100";
                case 0xD5: return "11010101";
                case 0xD6: return "11010110";
                case 0xD7: return "11010111";
                case 0xD8: return "11011000";
                case 0xD9: return "11011001";
                case 0xDA: return "11011010";
                case 0xDB: return "11011011";
                case 0xDC: return "11011100";
                case 0xDD: return "11011101";
                case 0xDE: return "11011110";
                case 0xDF: return "11011111";
                case 0xE0: return "11100000";
                case 0xE1: return "11100001";
                case 0xE2: return "11100010";
                case 0xE3: return "11100011";
                case 0xE4: return "11100100";
                case 0xE5: return "11100101";
                case 0xE6: return "11100110";
                case 0xE7: return "11100111";
                case 0xE8: return "11101000";
                case 0xE9: return "11101001";
                case 0xEA: return "11101010";
                case 0xEB: return "11101011";
                case 0xEC: return "11101100";
                case 0xED: return "11101101";
                case 0xEE: return "11101110";
                case 0xEF: return "11101111";
                case 0xF0: return "11110000";
                case 0xF1: return "11110001";
                case 0xF2: return "11110010";
                case 0xF3: return "11110011";
                case 0xF4: return "11110100";
                case 0xF5: return "11110101";
                case 0xF6: return "11110110";
                case 0xF7: return "11110111";
                case 0xF8: return "11111000";
                case 0xF9: return "11111001";
                case 0xFA: return "11111010";
                case 0xFB: return "11111011";
                case 0xFC: return "11111100";
                case 0xFD: return "11111101";
                case 0xFE: return "11111110";
                case 0xFF: return "11111111";
            }

            throw new ArgumentOutOfRangeException(nameof(b), "Invalid Byte: " + b);
        }
    }
}
