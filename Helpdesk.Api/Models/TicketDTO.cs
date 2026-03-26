namespace Helpdesk.Api.Models;

public class TicketDTO
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    // Note: We EXCLUDE Id, Status, and CreatedAt
}