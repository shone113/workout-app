using WebApplication1.DTO;

namespace WebApplication1.Core.Interfaces
{
    public interface IWorkoutService
    {
        Task<WorkoutDTO> CreateWorkoutAsync(int userId, WorkoutDTO dto);
        Task<WorkoutDTO?> GetByIdAsync(int id, int userId);
        Task<IEnumerable<WorkoutDTO>> GetWorkoutsInRangeAsync(int userId, DateTime startDate, DateTime endDate);

    }
}
