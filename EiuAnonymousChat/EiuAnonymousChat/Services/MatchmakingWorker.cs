namespace EiuAnonymousChat.Api.Services;

public class MatchmakingWorker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Chỗ này sẽ chứa logic quét bảng MatchQueue liên tục
            // Tìm thấy 2 người -> Xóa khỏi queue -> Tạo ChatRoom -> Bắn tín hiệu SignalR

            // Tạm dừng 3 giây cho mỗi vòng lặp để tránh quá tải CPU server
            await Task.Delay(3000, stoppingToken);
        }
    }
}