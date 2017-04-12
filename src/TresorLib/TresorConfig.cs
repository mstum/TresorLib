#region LICENSE
/* Copyright (C) 2017 Michael Stum <opensource@stum.de>

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

namespace Tresor
{
    public sealed class TresorConfig
    {
        private static readonly Func<TresorConfig> DefaultConfigFactory = () => new TresorConfig
        {
            // defaults as set on https://getvau.lt/
            PasswordLength = 20,
            MaxRepetition = 0,
            LowercaseLetters = AllowedMode.Allowed,
            UppercaseLetters = AllowedMode.Allowed,
            Numbers = AllowedMode.Allowed,
            Dash = AllowedMode.Allowed,
            Space = AllowedMode.Allowed,
            Symbols = AllowedMode.Allowed,
            RequiredCount = 2
        };

        public static TresorConfig Default => DefaultConfigFactory();

        /// <summary>
        /// Generated Password length
        /// </summary>
        public int PasswordLength { get; set; }

        /// <summary>
        /// How often can the same char be repeated? (e.g., MaxRepetition 1 disallows "mm")
        /// </summary>
        public int MaxRepetition { get; set; }

        /// <summary>
        /// a-z
        /// </summary>
        public AllowedMode LowercaseLetters { get; set; }

        /// <summary>
        /// A-Z
        /// </summary>
        public AllowedMode UppercaseLetters { get; set; }

        /// <summary>
        /// 0-9
        /// </summary>
        public AllowedMode Numbers { get; set; }

        /// <summary>
        /// - and _
        /// </summary>
        public AllowedMode Dash { get; set; }

        /// <summary>
        /// The space character
        /// </summary>
        public AllowedMode Space { get; set; }

        /// <summary>
        /// <see cref="Dash"/> and these special characters: ! " # $ % ' ( ) * + , . / : ; =  ? @ [ \ ] ^ { | } ~ &lt; &gt; &amp;
        /// </summary>
        public AllowedMode Symbols { get; set; }

        /// <summary>
        /// If using <see cref="AllowedMode.Required"/>, how often must a character from the required group appear?
        /// </summary>
        public int RequiredCount { get; set; }

        public enum AllowedMode
        {
            /// <summary>
            /// A character from this group MUST appear in the password, at least <see cref="TresorConfig.RequiredCount"/> times
            /// </summary>
            Required,

            /// <summary>
            /// A character from this group MAY appear in the password
            /// </summary>
            Allowed,

            /// <summary>
            /// No character from this group can appear in the password
            /// </summary>
            Forbidden
        }
    }
}