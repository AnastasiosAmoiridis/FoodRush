using Common;
using FluentValidation;
using Services.DTOs;


namespace Services.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(EntityConstraints.MIN_PASSWORD_LENGTH)
                .Matches("[A-Z]")
                    .WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"\d")
                    .WithMessage("Password must contain at least one number.")
                .Matches(@"[^A-Za-z0-9]")
                    .WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .MinimumLength(EntityConstraints.MIN_PHONE_LENGTH)
                .MaximumLength(EntityConstraints.MAX_PHONE_LENGTH);

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();
        }
    }
}
