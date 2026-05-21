using System.ComponentModel.DataAnnotations;

namespace EiuAnonymousChat.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public required string EiuEmail { get; set; }
        public required string FullName { get; set; }
        public required string StudentID { get; set; }
        public string? Gender { get; set; }
        public string? AvatarUrl { get; set; }
        public bool IsBanned { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
