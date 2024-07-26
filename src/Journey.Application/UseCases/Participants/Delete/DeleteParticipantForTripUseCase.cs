using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Participants.Delete;

public class DeleteParticipantForTripUseCase
{
    public void Execute(Guid tripId, Guid participantId)
    {
        var dbContext = new JourneyDbContext();
        var participant = dbContext.Participants.FirstOrDefault(a => a.Id == participantId && a.TripId == tripId);
        
        if (participant is null)
        {
            throw new NotFoundException(ResourceErrorMessages.PARTICIPANT_NOT_FOUND);
        }

        dbContext.Participants.Remove(participant);
        dbContext.SaveChanges();
    }
}