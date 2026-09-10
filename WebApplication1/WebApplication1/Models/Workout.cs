namespace WebApplication1.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public ExerciseType ExerciseType { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public int BurnedCalories { get; set; }
        public int IntensityLevel { get; set; }
        public int TirednessLevel { get; set; }
        public string Notes { get; set; }
        public User User { get; set; } = null!;  
    }
}
