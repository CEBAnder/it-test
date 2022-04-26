using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace it_test_producer.Areas.UserManagement.AddUser.Validators
{
    public class PhoneNumberValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => typeof(PhoneNumberValidator<T>).Name;

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            return Regex.Match(value, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").Success;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "You must input correct phone number. Correct format: 0123456789, 012-345-6789, and (012)-345-6789";
    }
}
