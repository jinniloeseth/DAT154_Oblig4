using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Objects;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherObservationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeacherObservationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherObservation>>> GetAll()
        {
            return await _context.TeacherObservations
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TeacherObservation>> Create(
            TeacherObservation observation)
        {
            _context.TeacherObservations.Add(observation);

            await _context.SaveChangesAsync();

            return Ok(observation);
        }
    }
}