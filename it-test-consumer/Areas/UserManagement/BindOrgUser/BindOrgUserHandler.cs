using it_test_consumer.Data.Exceptions;
using it_test_consumer.Data.Models;
using it_test_consumer.Infrastructure.Exceptions;
using MediatR;
using static it_test_consumer.Data.Helpers.IRepository;

namespace it_test_consumer.Areas.UserManagement.BindOrgUser
{
    public class BindOrgUserHandler : IRequestHandler<BindOrgUserRequest>
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IRepository<Organisation> _organisationRepository;

        public BindOrgUserHandler(IRepository<User> usersRepository, IRepository<Organisation> organisationsRepository)
        {
            _usersRepository = usersRepository;
            _organisationRepository = organisationsRepository;
        }

        public async Task<Unit> Handle(BindOrgUserRequest request, CancellationToken cancellationToken)
        {
            User user;
            try
            {
                user = await _usersRepository.FindOne(user => user.Id == request.UserId);

                var org = await _organisationRepository.FindOne(org => org.Id == request.OrgId);
            }
            catch (EntityNotFoundException<User>)
            {
                throw new NotFoundException<User>(request.UserId);
            }
            catch (EntityNotFoundException<Organisation>)
            {
                throw new NotFoundException<Organisation>(request.OrgId);
            }

            user.OrgId = request.OrgId;

            await _usersRepository.Update(user);

            return Unit.Value;
        }
    }
}
