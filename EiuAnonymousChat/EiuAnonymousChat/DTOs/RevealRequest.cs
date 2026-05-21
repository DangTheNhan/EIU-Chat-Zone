namespace EiuAnonymousChat.Api.DTOs;

public class RevealRequest
{
    public Guid ChatRoomId { get; set; }
    public Guid UserId { get; set; }
}