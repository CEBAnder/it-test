using AutoFixture;
using FluentAssertions;
using FluentValidation.TestHelper;
using it_test_producer.Areas.UserManagement.AddUser;
using it_test_producer.Areas.UserManagement.AddUser.Validators;
using Xunit;

namespace it_test_producer.tests.Areas.UserManagement.AddUser.Validators
{
    public class AddUserRequestValidatorTests
    {
        private readonly AddUserRequestValidator _validator = new AddUserRequestValidator();

        [Fact]
        public void Validate_ShouldReturnOk_WhenCorrectRequest()
        {
            // Arrange
            var request = new AddUserRequest
            {
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0123456789",
                Email = "email@ya.ru"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldHaveErrors_WhenEmptyName()
        {
            // Arrange
            var request = new AddUserRequest
            {
                Surname = "Surname",
                PhoneNumber = "0123456789",
                Email = "email@ya.ru"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Validate_ShouldHaveErrors_WhenEmptySurname()
        {
            // Arrange
            var request = new AddUserRequest
            {
                Name = "Name",
                PhoneNumber = "0123456789",
                Email = "email@ya.ru"
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Surname);
        }

        [Fact]
        public void Validate_ShouldHaveErrors_WhenRandomRequest()
        {
            // Arrange
            var request = new Fixture().Create<AddUserRequest>();

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
