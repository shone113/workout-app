using WebApplication1.Core.Domain;

namespace WebApplication1.Core.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<Workout?> GetByIdAsync(int id);
        Task<IEnumerable<Workout>> GetAllByUserIdAsync(int userId);
        Task AddAsync(Workout workout);
        void Delete(Workout workout);
        Task SaveChangesAsync();
    }
}
