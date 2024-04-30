using FluentValidation;
using System.Security.AccessControl;

namespace BusinessLayer.Validator.User
{
    public class UserDtoUpdateValidator : AbstractValidator<UserDtoUpdate>
    {
        public UserDtoUpdateValidator()
        {
            RuleFor(prop => prop.FullName).MinimumLength(5).MaximumLength(50);
            RuleFor(prop => prop.Email).EmailAddress();
            RuleFor(prop => prop.Password).MinimumLength(6).Matches("[a-zA-Z0-9]");
        }
    }
}
