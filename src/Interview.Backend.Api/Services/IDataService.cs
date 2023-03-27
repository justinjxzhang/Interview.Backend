using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Services;

public interface IDataService {
    Task<Ticket> GetTicketAsync(User user, Guid ticketId);
    Task<Ticket> CreateTicketAsync(User user, Company company, string description);

    Task<User> GetUserByIdAsync(Guid id);
    Task<User> CreateUserAsync(string givenName, string familyName);
    
    Task<Company> GetCompanyByIdAsync(Guid companyId);
}