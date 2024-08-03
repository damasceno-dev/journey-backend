using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Links.Delete;

public class DeleteLinkForTripUseCase
{
    public void Execute(Guid tripId, Guid linkId)
    {
        var dbContext = new JourneyDbContext();
        var link = dbContext.Links.FirstOrDefault(a => a.Id == linkId && a.TripId == tripId);
        
        if (link is null)
        {
            throw new NotFoundException(ResourceErrorMessages.LINK_NOT_FOUND);
        }

        dbContext.Links.Remove(link);
        dbContext.SaveChanges();
    }
}