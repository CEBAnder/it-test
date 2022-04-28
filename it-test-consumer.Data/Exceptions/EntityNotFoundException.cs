namespace it_test_consumer.Data.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException() : base($"{typeof(T).Name} not found!")
        {
        }
    }
}
