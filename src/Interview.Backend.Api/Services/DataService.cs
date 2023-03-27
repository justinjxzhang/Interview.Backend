using Interview.Backend.Api.Exceptions;
using Interview.Backend.Data.Models;

namespace Interview.Backend.Api.Services;

public class DataService : IDataService
{
    private readonly IAuthorisationRepository _authRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IAccountManagerRepository _accountManagerRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICompanyRepository _companyRepository;

    public DataService(
        IAuthorisationRepository authRepository,
        ITicketRepository ticketRepository,
        IUserRepository userRepository,
        ICompanyRepository companyRepository
    ) {
        this._authRepository = authRepository;
        this._ticketRepository = ticketRepository;
        this._userRepository = userRepository;
        this._companyRepository = companyRepository;
    }

    public async Task<Ticket> CreateTicketAsync(User user, Company company, string description)
    {
        var isAuthorised = await this._authRepository.UserAuthorisedForCompany(user.Id, company.Id);
        if (!isAuthorised) {
            throw new AuthorisationException("Unauthorised access attempted");
        }
        else if (isAuthorised) {
            return this._ticketRepository.CreateAsync(
                user.Id,
                company.Id,
                description
            ).Result;
        }
        return default(Ticket);
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        return await this._userRepository.GetUserByIdAsync(userId);
    }

    public async Task<User> CreateUserAsync(string givenName, string familyName) {
        return await this._userRepository.AddUserAsync(givenName, familyName);
    }

    public async Task DeleteUserAsync(Guid id) {
        await this._userRepository.DeleteUserAsync(id);
    }

    public async Task<Company> GetCompanyByIdAsync(Guid companyId) {
        return await this._companyRepository.GetCompanyByIdAsync(companyId);
    }

    public async Task<Ticket> GetTicketAsync(User user, Guid ticketId)
    {
        var ticket = await _ticketRepository.GetByIdAsync(ticketId);
        var isAuthorised = await this._authRepository.UserAuthorisedForCompany(user.Id, ticket.CompanyId);
        if (isAuthorised) {
            return ticket;
        } else {
            throw new AuthorisationException("Unauthorised access attempted");
        }
    }
}