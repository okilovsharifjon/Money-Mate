using FluentValidation;

namespace BusinessLayer.Validator.Transaction
{
    public class UserSettingsDtoValidator : AbstractValidator<UserSettingsDto>
    {
        public UserSettingsDtoValidator()
        {
            RuleFor(prop => prop.UserId).NotEmpty();
            RuleFor(prop => prop.Currency).NotEmpty().IsInEnum();
            
        }
    }
}
