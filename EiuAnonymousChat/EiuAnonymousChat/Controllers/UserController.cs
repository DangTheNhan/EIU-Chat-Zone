using EiuAnonymousChat.Api.DTOs;
using EiuAnonymousChat.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EiuAnonymousChat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly RevealService _revealService;

    public UserController(RevealService revealService)
    {
        _revealService = revealService;
    }

    [HttpPost("reveal")]
    public async Task<IActionResult> RevealUser(RevealRequest request)
    {
        var result = await _revealService.RevealUserAsync(request);
        return Ok(result);
    }
}