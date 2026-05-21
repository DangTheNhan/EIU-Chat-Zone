using EiuAnonymousChat.Api.Data;
using EiuAnonymousChat.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EiuAnonymousChat.Api.Services;

public class RevealService
{
    private readonly ApplicationDbContext _context;

    public RevealService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> RevealUserAsync(RevealRequest request)
    {
        // 1. Tìm ChatRoom
        var room = await _context.ChatRooms
            .FirstOrDefaultAsync(r => r.Id == request.ChatRoomId);

        if (room == null)
        {
            return "Chat room not found";
        }

        // 2. Kiểm tra user nào reveal
        if (room.User1Id == request.UserId)
        {
            room.User1Revealed = true;
        }
        else if (room.User2Id == request.UserId)
        {
            room.User2Revealed = true;
        }
        else
        {
            return "User does not belong to this room";
        }

        // 3. Nếu cả hai đã reveal
        if (room.User1Revealed && room.User2Revealed)
        {
            room.IsRevealed = true;
        }

        // 4. Save database
        await _context.SaveChangesAsync();

        return "Reveal request updated";
    }
}