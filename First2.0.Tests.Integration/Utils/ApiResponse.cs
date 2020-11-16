using System.Net;

namespace First2._0.Tests.Integration.Utils
{
    public class ApiResponse<T>
    {
        public string ContentAsString { get; set; }
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
