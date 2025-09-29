using FluentValidation;
using HotelProject.WebUI.Dtos.SendMessageDto;

namespace HotelProject.WebUI.ValidationRules.SendMessageValidationRules
{
    public class CreateSendMessageValidator : AbstractValidator<CreateSendMessageDto>
    {
        public CreateSendMessageValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Message title is required.")
                .MinimumLength(3).WithMessage("Message title must be at least 3 characters.")
                .MaximumLength(100).WithMessage("Message title cannot exceed 100 characters.");

            RuleFor(x => x.SenderName)
                .NotEmpty().WithMessage("Sender name is required.")
                .MinimumLength(2).WithMessage("Sender name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Sender name cannot exceed 50 characters.");

            RuleFor(x => x.SenderMail)
                .NotEmpty().WithMessage("Sender email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(100).WithMessage("Email address cannot exceed 100 characters.");

            RuleFor(x => x.ReceiverName)
                .NotEmpty().WithMessage("Receiver name is required.")
                .MinimumLength(2).WithMessage("Receiver name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Receiver name cannot exceed 50 characters.");

            RuleFor(x => x.ReceiverMail)
                .NotEmpty().WithMessage("Receiver email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(100).WithMessage("Email address cannot exceed 100 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Message content is required.")
                .MinimumLength(10).WithMessage("Message content must be at least 10 characters.")
                .MaximumLength(1000).WithMessage("Message content cannot exceed 1000 characters.");
        }
    }
}