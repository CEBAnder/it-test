using AutoFixture;
using FluentAssertions;
using FluentValidation;
using it_test_producer.Areas.UserManagement.AddUser.Validators;
using Xunit;

namespace it_test_producer.tests.Areas.UserManagement.AddUser.Validators
{
    public class EmailValidatorTests
    {
        private readonly IFixture _fixture = new Fixture();
        private readonly EmailValidator<string> _emailValidator = new EmailValidator<string>();

        public EmailValidatorTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void IsValid_ShouldReturnTrue_WhenValidEmail()
        {
            // Arrange
            var email = _fixture.Create<string>() + "@ya.ru";

            // Act
            var result = _emailValidator.IsValid(new ValidationContext<string>(string.Empty), email);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_ShouldReturnFalse_WhenInvalidEmail()
        {
            // Arrange
            var email = _fixture.Create<string>();

            // Act
            var result = _emailValidator.IsValid(new ValidationContext<string>(string.Empty), email);

            // Assert
            result.Should().BeFalse();
        }
    }
}
