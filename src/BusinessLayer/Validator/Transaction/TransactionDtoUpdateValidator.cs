using FluentValidation;

namespace BusinessLayer.Validator.Transaction
{
    public class TransactionDtoUpdateValidator : AbstractValidator<TransactionDtoUpdate>
    {
        public TransactionDtoUpdateValidator()
        {
            RuleFor(prop => prop.Time).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(prop => prop.Amount).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(decimal.MaxValue);
            RuleFor(prop => prop.Category).NotEmpty().MinimumLength(3).MinimumLength(50);
            RuleFor(prop => prop.Description).MinimumLength(15).MaximumLength(500);
        }
    }
}
