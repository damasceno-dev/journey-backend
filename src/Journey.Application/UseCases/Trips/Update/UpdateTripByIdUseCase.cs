using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.Update;

public class UpdateTripByIdUseCase
{
    public ResponseShortTripJson Execute(Guid tripId, RequestRegisterTripJson request)
    {
        Validate(request);
        var dbContext = new JourneyDbContext();
        var trip = dbContext.Trips.FirstOrDefault(t => t.Id == tripId);
        
        if (trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }

        trip.Name = request.Name;
        trip.StartDate = request.StartDate;
        trip.EndDate = request.EndDate;

        dbContext.Trips.Update(trip);
        dbContext.SaveChanges();
        
        return new ResponseShortTripJson
        {
            EndDate = trip.EndDate,
            StartDate = trip.StartDate,
            Name = trip.Name,
            Id = trip.Id
        };
    }
    
    private void Validate(RequestRegisterTripJson request)
    {
        var validator = new RegisterTripValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}