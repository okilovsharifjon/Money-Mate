using FluentValidation;
using System.Security.AccessControl;

namespace BusinessLayer.Validator.User
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(prop => prop.FullName).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(prop => prop.Email).NotEmpty().EmailAddress();
            RuleFor(prop => prop.Password).NotEmpty().MinimumLength(6).Matches("[a-zA-Z0-9]");
        }
    }
}
