# Tresor - a deterministic password generator
Tresor is a .net library (.net 4/netstandard 1.3 or newer) to generate passwords in a deterministic way, that is, the same inputs will yield the same outputs, but from simple inputs (Like the service name "twitter" and the passphrase "I'm the best 17-year old ever.") you will get a strong password like "`c<q_!^~,'.KTbPV=9^mU`".

This helps with the behavior of using the same passphrase for multiple sites, but is also not reliant on a password vault that you don't always tend to have with you (e.g., because it's a file on your computer and you're on the road) or requires you to trust a cloud-service to securely keep your data.

Internet Websites get compromised all the time - so frequently that [haveibeenpwned.com](https://haveibeenpwned.com) has been created for people to get notified whenever their email address shows up in a data breach. Troy Hunt has an amazing blog about web security issues and breaches, and [explains why you should use a Password Manager](https://www.troyhunt.com/only-secure-password-is-one-you-cant/).

Tresor is a port of [Vault](https://getvau.lt/) by [James Coglan](http://jcoglan.com/) to .net. When I first discovered Vault, it immediately checked the boxes I was looking for: It works everywhere as long as I have internet access, but it doesn't store any data that can be compromised. All I need to do is remember the service name and settings, and voila, there's my password without having to store it in yet another online database that can be compromised.

For more information about Vault, check the FAQ on [https://getvau.lt/faq.html](https://getvau.lt/faq.html).

Please note that this port is not endorsed or in any way associated with James Coglan.

## Usage
Check [the unit tests](https://github.com/mstum/TresorLib/blob/master/src/TresorLib.Tests/TresorLibTests.cs) for now.

# TODO
While the code works and behaves like the algorithm on https://getvau.lt/, it is not production ready.

* A lot of the VaultLib code needs to be restructured to use .net idioms instead of being an almost 1:1 port of JavaScript.
* Needs Documentation of how stuff works.

# Acknowledgements
* Based on [Vault](https://getvau.lt/) by [James Coglan](http://jcoglan.com/), licensed under GPLv3

# License
Copyright (C) 2017 Michael Stum <opensource@stum.de>

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/.