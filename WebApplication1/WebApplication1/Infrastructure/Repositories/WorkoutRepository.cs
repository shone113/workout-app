using Microsoft.EntityFrameworkCore;
using WebApplication1.Core.Domain;
using WebApplication1.Core.Interfaces;
using WebApplication1.Infrastructure.Data;

namespace WebApplication1.Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext _context;

        public WorkoutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Workout?> GetByIdAsync(int id)
        {
            return await _context.Workouts.FindAsync(id);
        }

        public async Task<IEnumerable<Workout>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId)
                .OrderByDescending(w => w.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Workout>> GetByUserIdAndDateRangeAsync(int userId, DateTime startDate, DateTime endDate)
        {
            var inclusiveEnd = endDate.Date.AddDays(1);

            return await _context.Workouts
                .Where(w => w.UserId == userId
                         && w.StartTime >= startDate.Date
                         && w.StartTime < inclusiveEnd)
                .OrderBy(w => w.StartTime)
                .ToListAsync();
        }

        public async Task AddAsync(Workout workout)
        {
            await _context.Workouts.AddAsync(workout);
        }

        public void Delete(Workout workout)
        {
            _context.Workouts.Remove(workout);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
