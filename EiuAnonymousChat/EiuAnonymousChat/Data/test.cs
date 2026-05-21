using EiuAnonymousChat.Models;

namespace EiuAnonymousChat.Api.Data;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Users.Any())
        {
            return;
        }

        var aliceId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var bobId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var carolId = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var davidId = Guid.Parse("44444444-4444-4444-4444-444444444444");

        var roomOneId = Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaa1");
        var roomTwoId = Guid.Parse("aaaaaaa2-aaaa-aaaa-aaaa-aaaaaaaaaaa2");

        var now = DateTime.UtcNow;

        context.Users.AddRange(
            new User
            {
                Id = aliceId,
                EiuEmail = "alice.nguyen@eiu.edu.vn",
                FullName = "Nguyen Thi Alice",
                StudentID = "20210001",
                Gender = "Female",
                AvatarUrl = "https://i.pravatar.cc/150?img=1",
                IsBanned = false,
                CreatedAt = now.AddDays(-30)
            },
            new User
            {
                Id = bobId,
                EiuEmail = "bob.tran@eiu.edu.vn",
                FullName = "Tran Van Bob",
                StudentID = "20210002",
                Gender = "Male",
                AvatarUrl = "https://i.pravatar.cc/150?img=2",
                IsBanned = false,
                CreatedAt = now.AddDays(-25)
            },
            new User
            {
                Id = carolId,
                EiuEmail = "carol.le@eiu.edu.vn",
                FullName = "Le Thi Carol",
                StudentID = "20210003",
                Gender = "Female",
                AvatarUrl = "https://i.pravatar.cc/150?img=3",
                IsBanned = false,
                CreatedAt = now.AddDays(-20)
            },
            new User
            {
                Id = davidId,
                EiuEmail = "david.pham@eiu.edu.vn",
                FullName = "Pham Van David",
                StudentID = "20210004",
                Gender = "Male",
                AvatarUrl = "https://i.pravatar.cc/150?img=4",
                IsBanned = false,
                CreatedAt = now.AddDays(-15)
            });

        context.MatchQueues.Add(new MatchQueue
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            UserId = davidId,
            ConnectionId = "sample-connection-david",
            JoinedAt = now.AddMinutes(-5)
        });

        context.ChatRooms.AddRange(
            new ChatRoom
            {
                Id = roomOneId,
                User1Id = aliceId,
                User2Id = bobId,
                AffinityScore = 72,
                IsRevealed = false,
                User1Revealed = false,
                User2Revealed = false,
                Status = "Active",
                CreatedAt = now.AddDays(-2),
                UpdatedAt = now.AddHours(-1)
            },
            new ChatRoom
            {
                Id = roomTwoId,
                User1Id = carolId,
                User2Id = davidId,
                AffinityScore = 88,
                IsRevealed = true,
                User1Revealed = true,
                User2Revealed = true,
                Status = "Closed",
                CreatedAt = now.AddDays(-4),
                UpdatedAt = now.AddDays(-1)
            });

        context.Messages.AddRange(
            new Message
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666661"),
                ChatRoomId = roomOneId,
                SenderId = aliceId,
                Content = "Xin chào, bạn học ngành gì vậy?",
                IsRead = true,
                CreatedAt = now.AddHours(-10)
            },
            new Message
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666662"),
                ChatRoomId = roomOneId,
                SenderId = bobId,
                Content = "Mình học Công nghệ thông tin, đang tìm nhóm làm bài tập.",
                IsRead = true,
                CreatedAt = now.AddHours(-9)
            },
            new Message
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666663"),
                ChatRoomId = roomOneId,
                SenderId = aliceId,
                Content = "Tuyệt, mình cũng đang cần bạn để luyện project.",
                IsRead = false,
                CreatedAt = now.AddHours(-8)
            },
            new Message
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666664"),
                ChatRoomId = roomTwoId,
                SenderId = carolId,
                Content = "Cuộc trò chuyện này đã được ghép thành công.",
                IsRead = true,
                CreatedAt = now.AddDays(-3)
            });

        context.ChatReports.Add(new ChatReport
        {
            Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            ChatRoomId = roomTwoId,
            ReportedUserId = davidId,
            ReporterId = carolId,
            ViolatingMessage = "Bạn gửi nội dung không phù hợp trong phòng chat.",
            Reason = "Harassment",
            Status = "Pending",
            CreatedAt = now.AddHours(-2)
        });

        context.SaveChanges();
    }
}