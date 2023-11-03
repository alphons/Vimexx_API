

namespace Vimexx_API.Api
{
	public class Response<T>
	{
		public string message { get; set; }
		public bool result { get; set; }
		public T data { get; set; }

	}
}
