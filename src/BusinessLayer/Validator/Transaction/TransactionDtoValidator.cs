using FluentValidation;

namespace BusinessLayer.Validator.Transaction
{
    public class TransactionDtoValidator : AbstractValidator<TransactionDto>
    {
        public TransactionDtoValidator()
        {
            RuleFor(prop => prop.UserId).NotEmpty();
            RuleFor(prop => prop.Time).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(prop => prop.Type).NotEmpty().IsInEnum();
            RuleFor(prop => prop.Amount).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(decimal.MaxValue);
            RuleFor(prop => prop.Category).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(prop => prop.Description).MaximumLength(500);
        }
    }
}
