using ContactsWebApp.Application.Contacts.Commands;
using FluentValidation;

namespace ContactsWebApp.Application.Contacts.Validators
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Phone number must be valid.");

            RuleFor(x => x.IBAN)
                .NotEmpty().WithMessage("IBAN is required.")
                .MaximumLength(34).WithMessage("IBAN cannot exceed 34 characters.")
                .Matches(@"^[A-Z]{2}[0-9]{2}[A-Z0-9]{1,30}$").WithMessage("IBAN must be valid.");
        }
    }
}
