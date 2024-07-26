using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Delete;

public class DeleteTripByIdUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new JourneyDbContext();

        var trip = dbContext.Trips.Include(t => t.Activities).Include(t=> t.Participants).FirstOrDefault(t => t.Id == id);
        var activities = dbContext.Activities.FirstOrDefault(a => a.TripId == id);
        var participants = dbContext.Participants.FirstOrDefault(p => p.TripId == id);

        if (trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }
        if (activities is null)
        {
            throw new NotFoundException(ResourceErrorMessages.ACTIVITY_NOT_FOUND);
        }
        if (participants is null)
        {
            throw new NotFoundException(ResourceErrorMessages.PARTICIPANT_NOT_FOUND);
        }

        dbContext.Trips.Remove(trip);
        dbContext.SaveChanges();
    }
}