using FluentValidation;
using FluentValidation.Validators;
using System.Net.Mail;

namespace it_test_producer.Areas.UserManagement.AddUser.Validators
{
    public class EmailValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => typeof(EmailValidator<T>).Name;

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            return MailAddress.TryCreate(value, out var _);
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "You must input correct email";
    }
}
