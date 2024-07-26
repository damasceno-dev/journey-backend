using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Participants.Register;

public class RegisterParticipantForTripValidator: AbstractValidator<RequestRegisterParticipantJson>
{
    public RegisterParticipantForTripValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
        RuleFor(request => request.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_EMPTY);
    }
}