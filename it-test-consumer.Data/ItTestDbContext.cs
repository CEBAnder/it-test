using it_test_consumer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace it_test_consumer.Data
{
    public class ItTestDbContext : DbContext
    {
        public DbSet<OrgUser> Users => Set<OrgUser>();

        public DbSet<Organisation> Organisations => Set<Organisation>();

        public ItTestDbContext(DbContextOptions<ItTestDbContext> options) : base(options)
        {
            Database.EnsureCreated();

            if (!Organisations.Any())
            {
                SeedDb();
            }
        }

        private void SeedDb()
        {
            var defaultOrganisations = new List<Organisation>
            {
                new Organisation{ Name = "Facebook" },
                new Organisation{ Name = "Apple" },
                new Organisation{ Name = "Amazon" },
                new Organisation{ Name = "Netflix" },
                new Organisation{ Name = "Google" }
            };
            Organisations.AddRange(defaultOrganisations);
            SaveChanges();
        }
    }
}
