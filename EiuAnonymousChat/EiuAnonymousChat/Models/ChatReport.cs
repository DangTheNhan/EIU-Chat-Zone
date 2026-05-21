using System.ComponentModel.DataAnnotations;

namespace EiuAnonymousChat.Models
{
    public class ChatReport
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ChatRoomId { get; set; }
        public Guid ReportedUserId { get; set; }
        public Guid? ReporterId { get; set; }

        public required string ViolatingMessage { get; set; }
        public required string Reason { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
