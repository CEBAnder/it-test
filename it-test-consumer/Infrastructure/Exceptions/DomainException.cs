using System.Net;

namespace it_test_consumer.Infrastructure.Exceptions
{
    public class DomainException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public DomainException(HttpStatusCode code, string message) : base(message)
        {
            StatusCode = code;
        }
    }
}
