using FluentValidation;
using HotelProject.WebUI.Dtos.BookingDto;

namespace HotelProject.WebUI.ValidationRules.BookingValidationRules
{
    public class UpdateBookingValidator : AbstractValidator<UpdateBookingDto>
    {
        public UpdateBookingValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Guest name is required.")
                .MinimumLength(2).WithMessage("Guest name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Guest name cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(100).WithMessage("Email address cannot exceed 100 characters.");

            RuleFor(x => x.CheckIn)
                .NotEmpty().WithMessage("Check-in date is required.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Check-in date cannot be in the past.");

            RuleFor(x => x.CheckOut)
                .NotEmpty().WithMessage("Check-out date is required.")
                .GreaterThan(x => x.CheckIn).WithMessage("Check-out date must be after check-in date.");

            RuleFor(x => x.AdultCount)
                .NotEmpty().WithMessage("Adult count is required.")
                .Must(x => int.TryParse(x, out var result) && result >= 1 && result <= 10)
                .WithMessage("Adult count must be between 1 and 10.");

            RuleFor(x => x.ChildrenCount)
                .NotEmpty().WithMessage("Children count is required.")
                .Must(x => int.TryParse(x, out var result) && result >= 0 && result <= 10)
                .WithMessage("Children count must be between 0 and 10.");

            RuleFor(x => x.RoomCount)
                .NotEmpty().WithMessage("Room count is required.")
                .Must(x => int.TryParse(x, out var result) && result >= 1 && result <= 10)
                .WithMessage("Room count must be between 1 and 10.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(x => new[] { "Pending", "Approved", "Rejected", "Waiting" }.Contains(x))
                .WithMessage("Status must be one of: Pending, Approved, Rejected, Waiting.");

            RuleFor(x => x.SpecialRequest)
                .MaximumLength(500).WithMessage("Special request cannot exceed 500 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            // Custom validation: Check-out date should be at least 1 day after check-in
            RuleFor(x => x)
                .Must(x => (x.CheckOut - x.CheckIn).TotalDays >= 1)
                .WithMessage("Minimum stay is 1 night.")
                .When(x => x.CheckIn != default && x.CheckOut != default);

            // Custom validation: Maximum stay limit
            RuleFor(x => x)
                .Must(x => (x.CheckOut - x.CheckIn).TotalDays <= 365)
                .WithMessage("Maximum stay is 365 nights.")
                .When(x => x.CheckIn != default && x.CheckOut != default);
        }
    }
}