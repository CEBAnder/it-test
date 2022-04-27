using FluentAssertions;
using FluentValidation;
using it_test_producer.Areas.UserManagement.AddUser.Validators;
using Xunit;

namespace it_test_producer.tests.Areas.UserManagement.AddUser.Validators
{
    public class PhoneNumberValidatorTests
    {
        private readonly PhoneNumberValidator<string> _phoneNumberValidator = new PhoneNumberValidator<string>();

        [Theory]
        [InlineData("0123456789")]
        [InlineData("012-345-6789")]
        [InlineData("(012)-345-6789")]
        public void IsValid_ShouldReturnTrue_WhenValidPhoneNumber(string phoneNumber)
        {
            // Arrange
            // Act
            var result = _phoneNumberValidator.IsValid(new ValidationContext<string>(string.Empty), phoneNumber);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("")]
        [InlineData("01234567890")]
        [InlineData("abcd")]
        public void IsValid_ShouldReturnFalse_WhenInvalidPhoneNumber(string phoneNumber)
        {
            // Arrange
            // Act
            var result = _phoneNumberValidator.IsValid(new ValidationContext<string>(string.Empty), phoneNumber);

            // Assert
            result.Should().BeFalse();
        }
    }
}
