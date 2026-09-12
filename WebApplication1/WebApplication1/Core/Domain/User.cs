using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Core.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
