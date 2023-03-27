using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Tests;

public class MockSlowTicketRepository : ITicketRepository
{
    private readonly List<Ticket> tickets = new List<Ticket>();
    public async Task<Ticket> CreateAsync(Guid reporterId, Guid companyId, string description)
    {
        await Task.Delay(500);
        var ticket = new Ticket() {
            Id = Guid.NewGuid(),
            CompanyId = companyId,
            ReporterId = reporterId,
            Description = description
        };
        this.tickets.Add(ticket);
        return ticket;
    }

    public async Task<Ticket> GetByIdAsync(Guid ticketId)
    {
        await Task.Delay(500);
        return this.tickets.FirstOrDefault(x => x.Id == ticketId);
    }
}