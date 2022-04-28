using System.Net;

namespace it_test_consumer.Infrastructure.Exceptions
{
    public class NotFoundException<T> : DomainException where T : class
    {
        public NotFoundException(int id):base(HttpStatusCode.NotFound, $"{typeof(T).Name} with Id = {id} not found!")
        {
        }
    }
}
