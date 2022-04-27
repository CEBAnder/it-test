using System.Net;

namespace it_test_consumer.Infrastructure.Exceptions
{
    public class EntityNotFoundException<T> : DomainException where T : class
    {
        public EntityNotFoundException(int id):base(HttpStatusCode.NotFound, $"{typeof(T).Name} with Id = {id} not found!")
        {
        }
    }
}
