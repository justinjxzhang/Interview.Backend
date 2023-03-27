using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Services;

public interface ITicketRepository {
    Task<Ticket> CreateAsync(Guid reporterId, Guid companyId, string description);
    Task<Ticket> GetByIdAsync(Guid ticketId);
}