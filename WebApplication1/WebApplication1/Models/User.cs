using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
