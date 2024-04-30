using FluentValidation;

namespace BusinessLayer
{
    public class GoalDtoValidator : AbstractValidator<GoalDto>
    {
        public GoalDtoValidator()
        {
            RuleFor(prop => prop.UserId).NotEmpty();
            RuleFor(prop => prop.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(prop => prop.AmountOfMoney).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(decimal.MaxValue);
            RuleFor(prop => prop.Term).GreaterThanOrEqualTo(DateTime.Now.AddDays(1));
        }
    }
}
