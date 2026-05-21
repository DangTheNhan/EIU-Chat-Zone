using EiuAnonymousChat.Api.DTOs;
using EiuAnonymousChat.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EiuAnonymousChat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly ReportService _reportService;

    public ReportController(ReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateReport(CreateReportRequest request)
    {
        await _reportService.CreateReportAsync(request);

        return Ok("Report created successfully");
    }
}