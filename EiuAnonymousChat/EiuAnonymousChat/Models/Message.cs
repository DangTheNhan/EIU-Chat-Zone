using System.ComponentModel.DataAnnotations;

namespace EiuAnonymousChat.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ChatRoomId { get; set; }
        public Guid SenderId { get; set; }
        public required string Content { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
