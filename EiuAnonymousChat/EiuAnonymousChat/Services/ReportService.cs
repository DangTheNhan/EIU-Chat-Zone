using EiuAnonymousChat.Api.Data;
using EiuAnonymousChat.Api.DTOs;
using EiuAnonymousChat.Models;

namespace EiuAnonymousChat.Api.Services;

public class ReportService
{
    private readonly ApplicationDbContext _context;

    public ReportService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateReportAsync(CreateReportRequest request)
    {
        var report = new ChatReport
        {
            Id = Guid.NewGuid(),
            ChatRoomId = request.ChatRoomId,
            ReporterId = request.ReporterId,
            ReportedUserId = request.ReportedUserId,
            ViolatingMessage = request.ViolatingMessage,
            Reason = request.Reason,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        _context.ChatReports.Add(report);

        await _context.SaveChangesAsync();
    }
}