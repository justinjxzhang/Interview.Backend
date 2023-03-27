using Interview.Backend.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Backend.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{

    private readonly ILogger<TicketController> _logger;
    private readonly IDataService _dataService;

    public TicketController(
        ILogger<TicketController> logger,
        IDataService dataService
    ) {
        _logger = logger;
        _dataService = dataService;
    }

    [HttpGet]
    public async Task<IActionResult> CreateNewTicket(
        Guid userId,
        Guid companyId,
        string description
    ) {
        var user = _dataService.GetUserByIdAsync(userId).Result;
        var company = _dataService.GetCompanyByIdAsync(companyId).Result;

        var newTicket = await this._dataService.CreateTicketAsync(
            user, company, description
        );

        return new CreatedResult("", newTicket);
    }
}
