using Journey.Communication.Enums;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetById;

public class GetTripByIdUseCase
{
    public ResponseTripJson Execute(Guid id)
    {
        var dbContext = new JourneyDbContext();
        var trip = dbContext.Trips.Include(t => t.Activities).Include(t=> t.Participants).Include(l=>l.Links)
            .FirstOrDefault(t => t
            .Id 
            == id);
        
        if (trip is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }
        
        return new ResponseTripJson
        {
            Id = trip.Id,
            Name = trip.Name,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            Activities = trip.Activities.Select(a => new ResponseActivityJson
            {
                Id = a.Id, Name = a.Name, Date = a.Date, Status = (Communication.Enums.ActivityStatus)a.Status
            }).ToList(),
            Participants = trip.Participants.Select(p => new ResponseParticipantJson
            {
                Id = p.Id, Name = p.Name, Email = p.Email, IsConfirmed = (ConfirmedStatus)p.IsConfirmed
            }).ToList(),
            Links = trip.Links.Select(p => new ResponseLinkJson
            {
                Id = p.Id, Title = p.Title, Url = p.Url,
            }).ToList()
        };
    }
}