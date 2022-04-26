using FluentValidation;

namespace it_test_producer.Areas.UserManagement.AddUser.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(user => user.Name).NotEmpty();
            RuleFor(user => user.Surname).NotEmpty();
            RuleFor(user => user.PhoneNumber).NotEmpty().SetValidator(new PhoneNumberValidator<AddUserRequest>());
            RuleFor(user => user.Email).NotEmpty().SetValidator(new EmailValidator<AddUserRequest>());
        }
    }
}
