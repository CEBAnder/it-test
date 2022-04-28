using it_test_consumer.Data.Extensions;
using it_test_consumer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace it_test_consumer.Data
{
    public class ItTestDbContext : DbContext
    {
        public virtual DbSet<User> Users => Set<User>();

        public virtual DbSet<Organisation> Organisations => Set<Organisation>();

        public ItTestDbContext()
        {
        }

        public ItTestDbContext(DbContextOptions<ItTestDbContext> options) : base(options)
        {
            Database.EnsureCreated();

            if (!Users.Any())
            {
                SeedUsers().GetAwaiter().GetResult();
            }

            if (!Organisations.Any())
            {
                SeedOrnanisations().GetAwaiter().GetResult();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureUsers();
        }

        private async Task SeedUsers()
        {
            var defaultUsers = new List<User>()
            {
                new User{ Name = "Mark", Surname = "Zuckerberg", Email = "mz@fb.com", PhoneNumber = "1111111111" },
                new User{ Name = "Steve", Surname = "Jobs", Email = "sj@apple.com", PhoneNumber = "2222222222" },
                new User{ Name = "Jeff", Surname = "Bezos", Email = "jb@amazon.com", PhoneNumber = "3333333333" },
                new User{ Name = "Reed", Surname = "Hastings", Email = "rh@netflix.com", PhoneNumber = "4444444444" },
                new User{ Name = "Pichai", Surname = "Sundararajan", Email = "pc@google.com", PhoneNumber = "5555555555" }
            };
            await Users.AddRangeAsync(defaultUsers);
            await SaveChangesAsync();
        }

        private async Task SeedOrnanisations()
        {
            var defaultOrganisations = new List<Organisation>
            {
                new Organisation{ Name = "Facebook" },
                new Organisation{ Name = "Apple" },
                new Organisation{ Name = "Amazon" },
                new Organisation{ Name = "Netflix" },
                new Organisation{ Name = "Google" }
            };
            await Organisations.AddRangeAsync(defaultOrganisations);
            await SaveChangesAsync();
        }
    }
}
