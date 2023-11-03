
namespace Vimexx_API.Api
{
	public class DnsRecords 
	{
		public List<DnsRecord> dns_records { get; set; }
	}

	public class GetDNSResponse : Response<DnsRecords>
	{
	}
}
