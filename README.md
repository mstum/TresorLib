# Tresor - a deterministic password generator
Tresor is a .net library (.net 4/netstandard 1.3 or newer) to generate passwords in a deterministic way, that is, the same inputs will yield the same outputs, but from simple inputs (Like the service name "twitter" and the passphrase "I'm the best 17-year old ever.") you will get a strong password like "`c<q_!^~,'.KTbPV=9^mU`".

This helps with the behavior of using the same passphrase for multiple sites, but is also not reliant on a password vault that you don't always tend to have with you (e.g., because it's a file on your computer and you're on the road) or requires you to trust a cloud-service to securely keep your data.

Internet Websites get compromised all the time - so frequently that [haveibeenpwned.com](https://haveibeenpwned.com) has been created for people to get notified whenever their email address shows up in a data breach. Troy Hunt has an amazing blog about web security issues and breaches, and [explains why you should use a Password Manager](https://www.troyhunt.com/only-secure-password-is-one-you-cant/).

Tresor is a port of [Vault](https://getvau.lt/) by [James Coglan](http://jcoglan.com/) to .net. When I first discovered Vault, it immediately checked the boxes I was looking for: It works everywhere as long as I have internet access, but it doesn't store any data that can be compromised. All I need to do is remember the service name and settings, and voila, there's my password without having to store it in yet another online database that can be compromised.

For more information about Vault, check the FAQ on [https://getvau.lt/faq.html](https://getvau.lt/faq.html).

Please note that this port is not endorsed or in any way associated with James Coglan.

## Usage
Call `Tresor.GeneratePassword` with the service name, passphrase and a `TresorConfig`. For example:

```cs
var service = "twitter";
var phrase = "I'm the best 17-year old ever.";
var password = Tresor.GeneratePassword(service, phrase, TresorConfig.Default);

// password => c;q- q}+&,KTbPVn9]mh
```

A `service name` is something you pick to uniquely identify services, e.g., `twitter`, `facebook`, `my bank`.

The `passphrase` is a second phrase that you choose. Usually, this is your password that you use everywhere because you can remember it, but don't want to use everywhere anymore because reusing passwords is highly insecure.

The `TresorConfig` defines how the password is generated. Properties include:

* `PasswordLength` (default: 20) - how long should the generated password be? The longer, the better, but some sites restrict the length, sometimes to something comical like 10 characters
* `MaxRepetition` (default: 0) - how often can a character be repeated. For example, if this is set to 1, then there could be no `nn` in the password, as the character `n` is repeated 2 times. Do note that `nan` is valid, as the character `n` is not immediately repeated. The value 0 means that unlimited repetitions are okay.
* Character classes: `LowercaseLetters`, `UppercaseLetters`, `Numbers`, `Dash`, `Space` and `Symbols` can be set to one of three modes:
    * `Allowed` (default): Characters from this character class may appear in the generated password, though that's not guaranteed
    * `Required`: Characters from this character class MUST appear in the generated password
    * `Forbidden`: Characters from this character class MUST NOT appear in the generated password
    * Character classes are:
        * `LowercaseLetters`: `a`-`z`
        * `UppercaseLetters`: `A`-`Z`
        * `Numbers`: `0`-`9`
        * `Dash`: `-` and `_` (hyphen and underscore)
        * `Space`: A space: ` `
        * `Symbols`: `-` `_` `!` `"` `#` `$` `%` `'` `(` `)` `*` `+` `,` `.` `/` `:` `;` `=` `?` `@` `[` `\` `]` `^` `{` `|` `}` `~` `&` `<` `>`
* `RequiredCount` (default: 2): If any character classes are set to `AllowedMode.Require`, how many characters of that group must appear in the output?

Example of a more complex TresorConfig:
```cs
var config = TresorConfig.Default;
config.PasswordLength = 14; // Generated password will be 14 characters long
config.Space = TresorConfig.AllowedMode.Forbidden; // The space MUST NOT appear in the password
config.Symbols = TresorConfig.AllowedMode.Forbidden; // No symbols must appear in the password
config.LowercaseLetters = TresorConfig.AllowedMode.Required; // At least 2 lowercase letters must appear
config.Numbers = TresorConfig.AllowedMode.Required; // At least 2 numbers must appear
config.MaxRepetition = 1; // Do not repeat any characters
config.RequiredCount = 2; // Of every required group, at least 2 characters must appear
```

Do note that the `RequiredCount` is set for all character classes, so you can't say "at least 2 numbers and 3 lowercase letters". Also note that in the above example, the `PasswordLength` must be at least 4 because we need space for at least 2 numbers and 2 lowercase letters. Setting the `PasswordLength` too small will throw a `System.InvalidOperationException : Length too small to fit all required characters`.

Also note that if you set all character classes to `Forbidden`, TresorLib will throw a `System.InvalidOperationException : No characters available to create a password`.

The `service name` and `passphrase` can contain special/unicode characters. The generated password will always be ASCII-compliant - see the character classes above.

# Acknowledgements
* Based on [Vault](https://getvau.lt/) by [James Coglan](http://jcoglan.com/), licensed under GPLv3

# License
Copyright (C) 2017 Michael Stum <opensource@stum.de>

Adapted from Vault, copyright (C) 2012-2014 James Coglan - https://github.com/jcoglan/vault

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/.