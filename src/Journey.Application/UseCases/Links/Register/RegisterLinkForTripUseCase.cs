using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Links.Register;

public class RegisterLinkForTripUseCase
{
    
    public ResponseLinkJson Execute(Guid tripId, RequestRegisterLinkJson request)
    {
        var dbContext = new JourneyDbContext();
        var trip = dbContext.Trips.FirstOrDefault(t => t.Id == tripId);

        if (trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }
        
        Validate(trip, request);
        var link = new Link
        {
            Title = request.Title, Url = request.Url, TripId = trip.Id
        };

        dbContext.Links.Add(link);
        dbContext.SaveChanges();

        var response = new ResponseLinkJson
        {
            Id = link.Id, Title = link.Title, Url = link.Url,
        };

        return response;
    }

    private void Validate(Trip trip, RequestRegisterLinkJson request)
    {
        var validator = new RegisterLinkForTripValidator();

        var result = validator.Validate(request);
        
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}