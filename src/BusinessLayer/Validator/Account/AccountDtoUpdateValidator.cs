

using FluentValidation;

namespace BusinessLayer
{
    public sealed class AccountDtoUpdateValidator : AbstractValidator<AccountDtoUpdate>
    {
        public AccountDtoUpdateValidator()
        {
            RuleFor(prop => prop.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(prop => prop.Balance).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(decimal.MaxValue);

        }
    }
}
