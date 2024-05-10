using FluentValidation;

namespace BusinessLayer.Validator.Transaction
{
    public class TransactionCategoryDtoValidator : AbstractValidator<TransactionCategoryDto>
    {
        public TransactionCategoryDtoValidator()
        {
            RuleFor(prop => prop.UserId).NotEmpty();
            RuleFor(prop => prop.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
