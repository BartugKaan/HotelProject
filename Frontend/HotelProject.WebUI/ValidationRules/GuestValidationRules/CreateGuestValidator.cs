using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules;

public class CreateGuestValidator: AbstractValidator<CreateGuestDto>
{
    public CreateGuestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("First name is required.")
            .MinimumLength(3).WithMessage("First name must be at least 3 characters.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Last name is required.")
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MinimumLength(3).WithMessage("City must be at least 3 characters.")
            .MaximumLength(50).WithMessage("City cannot exceed 50 characters.");
    }
}
