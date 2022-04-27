namespace it_test_consumer.Infrastructure.Exceptions
{
    public class EntityNotFoundException<T> : Exception where T : class
    {
        public EntityNotFoundException(int id):base($"{typeof(T).Name} with Id = {id} not found!")
        {
        }
    }
}
