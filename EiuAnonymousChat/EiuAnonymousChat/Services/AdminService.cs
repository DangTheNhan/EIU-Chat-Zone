using EiuAnonymousChat.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace EiuAnonymousChat.Api.Services;

public class AdminService
{
    private readonly ApplicationDbContext _context;

    public AdminService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Lấy danh sách report
    public async Task<object> GetReportsAsync()
    {
        return await _context.ChatReports.ToListAsync();
    }

    // Ban user
    public async Task<string> BanUserAsync(Guid userId)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return "User not found";
        }

        user.IsBanned = true;

        await _context.SaveChangesAsync();

        return "User banned successfully";
    }
}