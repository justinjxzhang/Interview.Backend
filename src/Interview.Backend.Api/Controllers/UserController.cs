using Interview.Backend.Api.DTO;
using Interview.Backend.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Backend.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IDataService _dataService;

    public UserController(
        ILogger<UserController> logger,
        IDataService dataService
    ) {
        _logger = logger;
        _dataService = dataService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(Guid id)
    {
        return Ok(await this._dataService.GetUserByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] NewUserDto newUserDetails)
    {
        var newUserModel = await this._dataService.CreateUserAsync(newUserDetails.GivenName, newUserDetails.FamilyName);
        return Ok(newUserModel);
    }
}
