using AutoMapper;
using it_test_consumer.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static it_test_consumer.Data.Helpers.IRepository;

namespace it_test_consumer.Areas.UserManagement.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, IEnumerable<GetUsersResponse>>
    {
        private readonly IRepository<User> usersRepository;
        private readonly IMapper _mapper;

        public GetUsersHandler(IRepository<User> usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetUsersResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var elemsToSkip = (request.PageNumber - 1) * request.PageSize;
            var users = await usersRepository
                .Include(u => u.Organisation)
                .OrderBy(u => u.Id)
                .Skip(elemsToSkip)
                .Take(request.PageSize)
                .ToListAsync();

            var result = _mapper.Map<IEnumerable<GetUsersResponse>>(users);
            return result;
        }
    }
}
