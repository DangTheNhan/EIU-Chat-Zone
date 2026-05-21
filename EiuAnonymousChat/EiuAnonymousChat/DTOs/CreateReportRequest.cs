namespace EiuAnonymousChat.Api.DTOs;

public class CreateReportRequest
{
    public Guid ChatRoomId { get; set; }
    public Guid ReporterId { get; set; }
    public Guid ReportedUserId { get; set; }
    public string ViolatingMessage { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
}