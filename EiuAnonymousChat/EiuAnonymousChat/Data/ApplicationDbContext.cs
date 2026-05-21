using EiuAnonymousChat.Models;
using Microsoft.EntityFrameworkCore;

namespace EiuAnonymousChat.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Khai báo 5 bảng tương ứng với 5 Models đã tạo
        public DbSet<User> Users { get; set; }
        public DbSet<MatchQueue> MatchQueues { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatReport> ChatReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Chỗ này để trống. Nhóm sẽ cấu hình Fluent API (Khóa ngoại, Unique, v.v.) tại đây sau.
        }
    }
}
