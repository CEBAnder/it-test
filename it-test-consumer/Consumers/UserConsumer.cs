using it_test_shared_contracts.Models;
using MassTransit;
using System.Text.Json;

namespace it_test_consumer.Consumers
{
    public class UserConsumer : IConsumer<User>
    {
        private readonly Serilog.ILogger _logger;

        public UserConsumer(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<User> context)
        {
            var user = context.Message;

            _logger.Information(JsonSerializer.Serialize(user));
            _logger.Information("Consumed successfully");

            return Task.CompletedTask;
        }
    }
}
