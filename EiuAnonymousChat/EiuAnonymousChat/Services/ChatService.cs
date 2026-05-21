using EiuAnonymousChat.Api.Data;
using EiuAnonymousChat.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EiuAnonymousChat.Api.Services;

public class ChatService
{
    private readonly ApplicationDbContext _context;

    public ChatService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ChatHistoryResponse>> GetChatHistoryAsync(Guid roomId)
    {
        return await _context.Messages
            .Where(m => m.ChatRoomId == roomId)
            .OrderBy(m => m.CreatedAt)
            .Select(m => new ChatHistoryResponse
            {
                Id = m.Id,
                ChatRoomId = m.ChatRoomId,
                SenderId = m.SenderId,
                Content = m.Content,
                IsRead = m.IsRead,
                CreatedAt = m.CreatedAt
            })
            .ToListAsync();
    }
}