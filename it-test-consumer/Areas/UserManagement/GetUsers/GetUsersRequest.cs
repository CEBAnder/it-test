using it_test_consumer.Data.Models;
using MediatR;

namespace it_test_consumer.Areas.UserManagement.GetUsers
{
    public class GetUsersRequest : IRequest<IEnumerable<GetUsersResponse>>
    {
        public int PageSize { get; init; }

        public int PageNumber { get; init; }
    }
}
