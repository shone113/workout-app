using System.ComponentModel.DataAnnotations;
using WebApplication1.Core.Domain;

namespace WebApplication1.DTO
{
    public class WorkoutDTO
    {
        public int Id { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public DateTime StartTime { get; set; }

        public int DurationMinutes { get; set; }

        public int BurnedCalories { get; set; }

        [Range(1, 10)]
        public int IntensityLevel { get; set; }

        [Range(1, 10)]
        public int TirednessLevel { get; set; }

        public string? Notes { get; set; }
    }
}
