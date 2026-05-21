using Microsoft.AspNetCore.SignalR;

namespace EiuAnonymousChat.Api.Hubs;

public class ChatHub : Hub
{
    // Cổng để client gửi tin nhắn trong phòng
    public async Task SendMessage(string roomId, string message)
    {
        // Logic lưu tin nhắn, kiểm tra từ khóa độc hại sẽ viết ở đây
    }
}