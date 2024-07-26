using Journey.Infrastructure.Enums;

namespace Journey.Infrastructure.Entities;

public class Participant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ConfirmedStatus IsConfirmed { get; set; } = ConfirmedStatus.Pending;
    public Guid TripId { get; set; }
}