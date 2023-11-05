
using Vimexx_API.Api;

var api = new VimexxApi();

await api.LoginAsync("123", "5aYB3pmxJNA4r2YdltRuDdnVTlNnLe22Ti0k26Z7", "<userid>", "<password>", false);

var result = await api.LetsEncryptAsync("voorbeeld.nl", "<challenge>");

Console.WriteLine($"result: {result.message}");

// verwijderen letsencrypt record
// result = await api.LetsEncryptAsync("voorbeeld.nl", null);
// Console.WriteLine($"result: {result.message}");

//var getdnsresponse = await api.GetDNSAsync("voorbeeld.nl");
//Console.WriteLine($"result: {getdnsresponse.message}");
//if (getdnsresponse.result)
//{
//	foreach (var r in getdnsresponse.data.dns_records)
//	{
//		Console.WriteLine($"{r.name}\t\t\t{r.type}\t{r.content}\t{r.prio}");
//	}
//}

//getdnsresponse.data.dns_records.Add(new DnsRecord() { name = "test1", type = "A", content = "1.2.3.4", ttl = 3600, prio = 0 });
//var savednsresponse = await api.SaveDNSAsync("voorbeeld.nl", getdnsresponse.data.dns_records);
//Console.WriteLine($"result: {savednsresponse.message}");

//Console.WriteLine("end");

