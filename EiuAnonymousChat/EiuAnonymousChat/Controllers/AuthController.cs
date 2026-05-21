using Microsoft.AspNetCore.Mvc;

namespace EiuAnonymousChat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin()
    {
        // Nhận token từ Google, check đuôi @eiu.edu.vn, sinh JWT nội bộ và trả về
        return Ok("Chức năng đang được xây dựng");
    }
}