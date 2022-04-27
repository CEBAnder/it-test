namespace it_test_consumer.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public int? OrgId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string? Patronymic { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Organisation? Organisation { get; set; }
    }
}
