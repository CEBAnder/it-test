using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace it_test_consumer.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ItTestDbContext>(options => options.UseSqlServer(config["Database:ConnectionString"]));

            return services;
        }
    }
}
