using EiuAnonymousChat.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EiuAnonymousChat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly ChatService _chatService;

    public ChatController(ChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("history/{roomId}")]
    public async Task<IActionResult> GetChatHistory(Guid roomId)
    {
        var messages = await _chatService.GetChatHistoryAsync(roomId);
        return Ok(messages);
    }
}