using it_test_consumer.Consumers;
using it_test_shared_contracts.Options;
using MassTransit;

namespace it_test_consumer.AppStart
{
    public static class MassTransitExtensions
    {
        public static void AddMassTransit(this IServiceCollection services, IConfiguration config)
        {
            var configSection = config.GetSection(RabbitMqOptions.SectionName);

            services.Configure<RabbitMqOptions>(configSection);

            var rabbitMqOptions = configSection.Get<RabbitMqOptions>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("users", e =>
                    {
                        e.ConfigureConsumer<UserConsumer>(context);
                    });

                    cfg.Host(rabbitMqOptions.Host, "/", h =>
                    {
                        h.Username(rabbitMqOptions.UserName);
                        h.Password(rabbitMqOptions.Password);
                    });
                });
            });
        }
    }
}
