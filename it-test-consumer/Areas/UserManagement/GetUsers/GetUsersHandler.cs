using AutoMapper;
using it_test_consumer.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace it_test_consumer.Areas.UserManagement.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, IEnumerable<GetUsersResponse>>
    {
        private readonly ItTestDbContext _dbFacade;
        private readonly IMapper _mapper;

        public GetUsersHandler(ItTestDbContext dbFacade, IMapper mapper)
        {
            _dbFacade = dbFacade;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetUsersResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var elemsToSkip = (request.PageNumber - 1) * request.PageSize;
            var users = await _dbFacade.Users
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
