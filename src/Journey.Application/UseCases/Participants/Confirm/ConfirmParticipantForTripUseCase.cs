using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Enums;

namespace Journey.Application.UseCases.Participants;

public class ConfirmParticipantForTripUseCase
{
    public void Execute(Guid tripId, Guid participantId)
    {
        var dbContext = new JourneyDbContext();
        var participant = dbContext.Participants.FirstOrDefault(a => a.Id == participantId && a.TripId == tripId);
        
        if (participant is null)
        {
            throw new NotFoundException(ResourceErrorMessages.PARTICIPANT_NOT_FOUND);
        }

        participant.IsConfirmed = ConfirmedStatus.Confirmed;

        dbContext.Participants.Update(participant);
        dbContext.SaveChanges();
    }
}