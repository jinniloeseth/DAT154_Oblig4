using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Objects;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalSignsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VitalSignsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/VitalSigns
        [HttpGet]
        public async Task<ActionResult<List<VitalSigns>>> GetAll()
        {
            return await _context.VitalSigns
                .Include(v => v.CaseScenario)
                .ToListAsync();
        }

        // POST: api/VitalSigns
        [HttpPost]
        public async Task<ActionResult<VitalSigns>> Create(VitalSigns vitalSigns)
        {
            _context.VitalSigns.Add(vitalSigns);

            await _context.SaveChangesAsync();

            return Ok(vitalSigns);
        }
    }
}