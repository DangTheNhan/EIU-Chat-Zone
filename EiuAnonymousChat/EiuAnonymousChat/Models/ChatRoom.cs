using System.ComponentModel.DataAnnotations;

namespace EiuAnonymousChat.Models
{
    public class ChatRoom
    {
        [Key]
        public Guid Id { get; set; }
        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }
        public int AffinityScore { get; set; } = 0;
        public bool IsRevealed { get; set; }
        public bool User1Revealed { get; set; }
        public bool User2Revealed { get; set; }

        public required string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
