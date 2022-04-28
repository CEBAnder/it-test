using it_test_consumer.Data.Helpers;
using it_test_consumer.Data.Models;

namespace it_test_consumer.Data.Repositories
{
    public class OrganisationsRepository : MsSQLRepository<Organisation>
    {
        public OrganisationsRepository(ItTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}
