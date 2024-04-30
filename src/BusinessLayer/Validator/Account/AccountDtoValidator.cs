using DataAccess;
using FluentValidation;
using FluentValidation.Validators;

namespace BusinessLayer
{
    public sealed class AccountDtoValidator : AbstractValidator<AccountDto>
    {
        public AccountDtoValidator()
        {
            RuleFor(prop => prop.UserId).NotEmpty();
            RuleFor(prop => prop.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(prop => prop.Balance).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(decimal.MaxValue);
            RuleFor(prop => prop.Type).NotEmpty().IsInEnum();

        }
    }
}
