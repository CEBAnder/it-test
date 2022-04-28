using it_test_consumer.Data.Models;
using it_test_consumer.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static it_test_consumer.Data.Helpers.IRepository;

namespace it_test_consumer.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ItTestDbContext>(options => options.UseSqlServer(config["Database:ConnectionString"]));
            services.AddScoped<IRepository<User>, UsersRepository>();
            services.AddScoped<IRepository<Organisation>, OrganisationsRepository>();

            return services;
        }
    }
}
