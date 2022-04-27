using it_test_consumer.Data;
using it_test_consumer.Data.Models;
using it_test_consumer.Infrastructure.Exceptions;
using MediatR;

namespace it_test_consumer.Areas.UserManagement.BindOrgUser
{
    public class BindOrgUserHandler : IRequestHandler<BindOrgUserRequest>
    {
        private readonly ItTestDbContext _dbContext;

        public BindOrgUserHandler(ItTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(BindOrgUserRequest request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.FirstOrDefault(user => user.Id == request.UserId);
            if (user == null)
                throw new EntityNotFoundException<User>(request.UserId);

            var org = _dbContext.Organisations.FirstOrDefault(org => org.Id == request.OrgId);
            if (org == null)
                throw new EntityNotFoundException<Organisation>(request.OrgId);

            user.OrgId = request.OrgId;

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
