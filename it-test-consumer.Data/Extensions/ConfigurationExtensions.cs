using it_test_consumer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace it_test_consumer.Data.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ModelBuilder ConfigureUsers(this ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder.Entity<User>();

            userBuilder
                .HasOne(u => u.Organisation)
                .WithMany()
                .HasForeignKey(u => u.OrgId)
                .HasConstraintName("FK_organisation_user");

            return modelBuilder;
        }
    }
}
