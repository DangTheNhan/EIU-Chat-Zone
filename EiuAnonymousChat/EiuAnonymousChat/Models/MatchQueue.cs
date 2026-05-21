using System.ComponentModel.DataAnnotations;

namespace EiuAnonymousChat.Models
{
    public class MatchQueue
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? ConnectionId { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    }
}
