using Interview.Backend.Api.DTO;
using Interview.Backend.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Backend.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{

    private readonly ILogger<CompanyController> _logger;
    private readonly IDataService _dataService;

    public CompanyController(
        ILogger<CompanyController> logger,
        IDataService dataService
    ) {
        _logger = logger;
        _dataService = dataService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyByIdAsync(Guid id)
    {
        return Ok(await this._dataService.GetCompanyByIdAsync(id));
    }
}