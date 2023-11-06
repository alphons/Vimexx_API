# Vimexx_API
Vimexx_API partly implementation for making the LetsEcnrypt DNS challenge (needed for wildcard certs)

Call LetsEncryptAsync to make the challenge record in DNS.

The challenge can be obtained by the https://github.com/fszlin/certes project.

```C#
var acme = new AcmeContext(WellKnownServers.LetsEncryptStagingV2);
var account = await acme.NewAccount("admin@example.com", true);

var order = await acme.NewOrder(new[] { "*.example.com" });

var authz = (await order.Authorizations()).First();
var dnsChallenge = await authz.Dns();
var dnsTxt = acme.AccountKey.DnsTxt(dnsChallenge.Token);
```
And use the dnsTxt to make the challende entry in DNS.

First create the WHMCS API credentials on the Vimexx website https://my.vimexx.nl/api

You also need your userid and password of your account for login to the Vimexx systems.

```C#
using Vimexx_API.Api;

var api = new VimexxApi();

await api.LoginAsync(
  "<vimexx-clientid>", 
  "<vimexx-client-secret>", 
  "<vimexx-userid>", 
  "<vimexx-password>");

var result = await api.LetsEncryptAsync("example.com", dnsTxt);
```

Now the DNS at Vimexx is setup to make the LetsEncryt DNS validation call.

```C#
await dnsChallenge.Validate();
```

Sometimes a few seconds has to be waited and retry for validation is successfull (loop it).

Download the certificate once validation is done (put in here your own credentials please)

```C#
var privateKey = KeyFactory.NewKey(KeyAlgorithm.ES256);
var cert = await order.Generate(new CsrInfo
{
    CountryName = "NL",
    State = "Flevoland",
    Locality = "Lelystad",
    Organization = "Van der Heijden BV",
    OrganizationUnit = "ICT"
    //CommonName = "example.com",
}, privateKey);
```

Two options here, exporting the pem data or making pfx file.

Export full chain certification in pem format.

```C#
var certPem = cert.ToPem();
```

Export PFX data to a file.

```C#
var pfxBuilder = cert.ToPfx(privateKey);
var pfxData = pfxBuilder.Build("cert-friendly-name", "<some-password>");
```

Save the pfx data and import them into a cert store.

```C#
await File.WriteAllBytesAsync("cert-name.pfx", pfxData);

var store = new X509Store("WebHosting", StoreLocation.LocalMachine))
store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);

var certificate = new X509Certificate2("cert-name.pfx", 
  "<some-password>",
  X509KeyStorageFlags.MachineKeySet |
  X509KeyStorageFlags.PersistKeySet |
  X509KeyStorageFlags.Exportable);

store.Add(certificate);
store.Close();
```
Now the cert can for example be selected in the IIS admin when binding to its https address.

For more information on getting the cert see the certes project.


Happy Cert-wild-carding.

