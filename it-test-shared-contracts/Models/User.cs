﻿namespace it_test_shared_contracts.Models
{
    public class User
    {
        public string Name { get; init; } = string.Empty;

        public string Surname { get; init; } = string.Empty;

        public string? Patronymic { get; init; }

        public string PhoneNumber { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;
    }
}
