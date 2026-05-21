using EiuAnonymousChat.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EiuAnonymousChat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly AdminService _adminService;

    public AdminController(AdminService adminService)
    {
        _adminService = adminService;
    }

    // GET api/Admin/reports
    [HttpGet("reports")]
    public async Task<IActionResult> GetReports()
    {
        var reports = await _adminService.GetReportsAsync();

        return Ok(reports);
    }

    // POST api/Admin/ban/{userId}
    [HttpPost("ban/{userId}")]
    public async Task<IActionResult> BanUser(Guid userId)
    {
        var result = await _adminService.BanUserAsync(userId);

        return Ok(result);
    }
}