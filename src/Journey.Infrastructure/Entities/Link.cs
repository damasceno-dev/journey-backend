namespace Journey.Infrastructure.Entities;

public class Link
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public Guid TripId { get; set; }
}