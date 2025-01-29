using System.ComponentModel.DataAnnotations;

namespace Vet_CIMAGT.Core.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } 

        [Required]
        public string Role { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

