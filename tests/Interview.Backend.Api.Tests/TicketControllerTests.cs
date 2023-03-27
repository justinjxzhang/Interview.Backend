using Interview.Backend.Api.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Interview.Backend.Api.Tests;

public class TicketControllerTests
{
    private readonly IAuthorisationRepository _authRepository;
    private readonly ITicketRepository _ticketRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICompanyRepository _companyRepository;

    public TicketControllerTests() {
        this._authRepository = new MockSlowAuthorisationRepository();
        this._ticketRepository = new MockSlowTicketRepository();
        this._userRepository = new MockSlowUserRepository();
        this._companyRepository = new MockSlowCompanyRepository();
    }

    [Fact(Timeout = 9000)]
    public async Task CreateShouldReturn201()
    {
        var dataService = new DataService(
            this._authRepository,
            this._ticketRepository,
            this._userRepository,
            this._companyRepository
        );

        var mockLogger = new Mock<ILogger<TicketController>>();
        var controller = new TicketController(mockLogger.Object, dataService);

        var userGuid = Guid.Parse("e6b990b1-82d2-4ed7-b1b5-5a5cf6277d1d");
        var companyGuid = Guid.Parse("867bbfe2-2024-4580-98c3-0c6bc716e038");
        var sw1 = System.Diagnostics.Stopwatch.StartNew();
        var response = await controller.CreateNewTicket(
            userGuid,
            companyGuid,
            "Test Description"
        );
        sw1.Stop();
        
        Assert.True(sw1.ElapsedMilliseconds < 9000, "Time exceeded 9000ms");
        Assert.Equal(201, ((IStatusCodeActionResult)response).StatusCode);
        
    }
}