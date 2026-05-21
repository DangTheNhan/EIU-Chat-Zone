using Microsoft.AspNetCore.SignalR;

namespace EiuAnonymousChat.Api.Hubs;

public class MatchmakingHub : Hub
{
    // Cổng để client gọi lên khi bấm nút "Tìm bạn chat"
    public async Task JoinQueue()
    {
        // Logic thêm user vào bảng MatchQueue sẽ viết ở đây
    }
}
