namespace it_test_consumer.Areas.UserManagement.GetUsers
{
    public class GetUsersResponse
    {
        public string? OrgName { get; init; }

        public string Name { get; init; } = string.Empty;

        public string Surname { get; init; } = string.Empty;

        public string? Patronymic { get; init; }

        public string PhoneNumber { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;
    }
}
