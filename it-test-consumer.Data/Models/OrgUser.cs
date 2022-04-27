namespace it_test_consumer.Data.Models
{
    public class OrgUser
    {
        public int Id { get; init; }

        public int? OrgId { get; init; }

        public string Name { get; init; } = string.Empty;

        public string Surname { get; init; } = string.Empty;

        public string? Patronymic { get; init; }

        public string PhoneNumber { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;
    }
}
