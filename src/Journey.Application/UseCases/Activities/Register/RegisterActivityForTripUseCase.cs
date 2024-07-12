using FluentValidation;
using FluentValidation.Results;
using Journey.Communication.Enums;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Activities.Register;

public class RegisterActivityForTripUseCase
{
    public ResponseActivityJson Execute(Guid tripId, RequestRegisterActivityJson request)
    {
        var dbContext = new JourneyDbContext();
        var trip = dbContext.Trips.FirstOrDefault(t => t.Id == tripId);

        if (trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }
        
        Validate(trip, request);
        var activity = new Activity
        {
            Name = request.Name, Date = request.Date, TripId = trip.Id
        };

        dbContext.Activities.Add(activity);
        dbContext.SaveChanges();

        var response = new ResponseActivityJson
        {
            Id = activity.Id, Name = activity.Name, Date = activity.Date, Status = (ActivityStatus)activity.Status
        };

        return response;
    }

    private void Validate(Trip trip, RequestRegisterActivityJson request)
    {
        var validator = new RegisterActivityValidator();

        var result = validator.Validate(request);

        if ((request.Date >= trip.StartDate && request.Date <= trip.EndDate) == false)
        {
            var invalidTripDateInterval = new ValidationFailure
            {
                PropertyName = "DateInvalid",
                ErrorMessage = ResourceErrorMessages.DATE_NOT_WITHIN_TRAVEL_PERIOD
            };
            result.Errors.Add(invalidTripDateInterval);
        }
        
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}