namespace Journey.Application.UseCases.Links.Register;
using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

public class RegisterLinkForTripValidator: AbstractValidator<RequestRegisterLinkJson>
{
    public RegisterLinkForTripValidator()
    {
        RuleFor(request => request.Title).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
        RuleFor(request => request.Url).NotEmpty().WithMessage(ResourceErrorMessages.URL_EMPTY);
    }
}