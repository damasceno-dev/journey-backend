using Journey.Application.UseCases.Links.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Links.Update;

public class UpdateLinkForTripUseCase
{
    public ResponseLinkJson Execute(Guid tripId, Guid linkId, RequestRegisterLinkJson request)
    {
        Validate(request);
        var dbContext = new JourneyDbContext();
        var link = dbContext.Links.FirstOrDefault(l => l.Id == linkId && l.TripId == tripId);
        
        if (link is null)
        {
            throw new NotFoundException(ResourceErrorMessages.LINK_NOT_FOUND);
        }

        link.Title = request.Title;
        link.Url = request.Url;

        dbContext.Links.Update(link);
        dbContext.SaveChanges();
        
        return new ResponseLinkJson
        {
            Id = link.Id,
            Url = link.Url,
            Title = link.Title,
        };
    }
    
    private void Validate(RequestRegisterLinkJson request)
    {
        var validator = new RegisterLinkForTripValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}