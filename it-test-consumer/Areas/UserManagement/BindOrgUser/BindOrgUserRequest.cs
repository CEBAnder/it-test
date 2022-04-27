using MediatR;

namespace it_test_consumer.Areas.UserManagement.BindOrgUser
{
    public class BindOrgUserRequest : IRequest
    {
        public int UserId { get; init; }

        public int OrgId { get; init; }
    }
}
