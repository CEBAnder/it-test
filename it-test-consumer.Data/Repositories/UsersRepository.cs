using it_test_consumer.Data.Helpers;
using it_test_consumer.Data.Models;

namespace it_test_consumer.Data.Repositories
{
    public class UsersRepository : MsSQLRepository<User>
    {
        public UsersRepository(ItTestDbContext dbContext) : base(dbContext)
        {
        }
    }
}
