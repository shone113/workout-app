using WebApplication1.Core.Domain;
using WebApplication1.Core.Interfaces;
using WebApplication1.DTO;

namespace WebApplication1.Core.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<WorkoutDTO> CreateWorkoutAsync(int userId, WorkoutDTO dto)
        {
            var workout = new Workout
            {
                UserId = userId,
                ExerciseType = dto.ExerciseType,
                StartTime = dto.StartTime,
                DurationMinutes = dto.DurationMinutes,
                BurnedCalories = dto.BurnedCalories,
                IntensityLevel = dto.IntensityLevel,
                TirednessLevel = dto.TirednessLevel,
                Notes = dto.Notes
            };

            await _workoutRepository.AddAsync(workout);
            await _workoutRepository.SaveChangesAsync();

            return MapToDto(workout);
        }

        public async Task<WorkoutDTO?> GetByIdAsync(int id, int userId)
        {
            var workout = await _workoutRepository.GetByIdAsync(id);

            if (workout == null || workout.UserId != userId)
                return null;

            return MapToDto(workout);
        }

        public async Task<IEnumerable<WorkoutDTO>> GetWorkoutsInRangeAsync(int userId, DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException("Početni datum ne može biti posle krajnjeg datuma.");

            var workouts = await _workoutRepository.GetByUserIdAndDateRangeAsync(userId, startDate, endDate);

            return workouts.Select(MapToDto);
        }

        private static WorkoutDTO MapToDto(Workout w)
        {
            return new WorkoutDTO
            {
                Id = w.Id,
                ExerciseType = w.ExerciseType,
                StartTime = w.StartTime,
                DurationMinutes = w.DurationMinutes,
                BurnedCalories = w.BurnedCalories,
                IntensityLevel = w.IntensityLevel,
                TirednessLevel = w.TirednessLevel,
                Notes = w.Notes
            };
        }
    }
}
