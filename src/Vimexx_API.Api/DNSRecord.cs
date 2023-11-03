
namespace Vimexx_API.Api
{
	public class DnsRecord
	{
		public string name { get; set; }
		public string type { get; set; }
		public string content { get; set; }
		public object prio { get; set; }
		public object ttl { get; set; }
	}
}
