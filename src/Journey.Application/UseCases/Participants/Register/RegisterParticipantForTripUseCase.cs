using FluentValidation.Results;
using Journey.Communication.Enums;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Participants.Register;

public class RegisterParticipantForTripUseCase
{
    
    public ResponseParticipantJson Execute(Guid tripId, RequestRegisterParticipantJson request)
    {
        var dbContext = new JourneyDbContext();
        var trip = dbContext.Trips.FirstOrDefault(t => t.Id == tripId);

        if (trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }
        
        Validate(trip, request);
        var participant = new Participant
        {
            Name = request.Name, Email = request.Email, TripId = trip.Id
        };

        dbContext.Participants.Add(participant);
        dbContext.SaveChanges();

        var response = new ResponseParticipantJson
        {
            Id = participant.Id, Name = participant.Name, Email = participant.Email, IsConfirmed = (ConfirmedStatus)
                participant.IsConfirmed
        };

        return response;
    }

    private void Validate(Trip trip, RequestRegisterParticipantJson request)
    {
        var validator = new RegisterParticipantForTripValidator();

        var result = validator.Validate(request);
        
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}