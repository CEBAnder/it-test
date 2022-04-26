namespace it_test_producer.Options
{
    public class RabbitMqOptions
    {
        public const string SectionName = "RabbitMq";

        public string Host { get; init; } = string.Empty;

        public string UserName { get; init; } = string.Empty;

        public string Password { get; init; } = string.Empty;
    }
}
