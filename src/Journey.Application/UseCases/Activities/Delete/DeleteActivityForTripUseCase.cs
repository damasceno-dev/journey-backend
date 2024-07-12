using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Activities.Delete;

public class DeleteActivityForTripUseCase
{
    public void Execute(Guid tripId, Guid activityId)
    {
        var dbContext = new JourneyDbContext();
        var activity = dbContext.Activities.FirstOrDefault(a => a.Id == activityId && a.TripId == tripId);
        
        if (activity is null)
        {
            throw new NotFoundException(ResourceErrorMessages.ACTIVITY_NOT_FOUND);
        }

        dbContext.Activities.Remove(activity);
        dbContext.SaveChanges();
    }
}