# Vimexx_API
Vimexx_API partly implementation for making the LetsEcnrypt DNS challenge (needed for wildcard certs)

First create the WHMCS API credentials on the Vimexx website https://my.vimexx.nl/api

You also need your userid and password of your account.

Call LetsEncryptAsync to make the challenge record in DNS.

Happy Cert-wild-carding.


```C#
using Vimexx_API.Api;

var api = new Api();

await api.LoginAsync("<clientid>", "<client-secret>", "<userid>", "<password>");

var result = await api.LetsEncryptAsync("voorbeeld.nl", "<challenge>");

Console.WriteLine($"result: {result.message}");
```
