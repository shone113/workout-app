using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Core.Interfaces;
using WebApplication1.Core.Services;
using WebApplication1.DTO;

namespace WebApplication1.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var workout = await _workoutService.GetByIdAsync(id, userId);

            if (workout == null)
                return NotFound();

            return Ok(workout);
        }

        [HttpGet]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            try
            {
                var workouts = await _workoutService.GetWorkoutsInRangeAsync(userId, startDate, endDate);
                return Ok(workouts);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkoutDTO dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var created = await _workoutService.CreateWorkoutAsync(userId, dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
