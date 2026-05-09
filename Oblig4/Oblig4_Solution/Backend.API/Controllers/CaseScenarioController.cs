using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Objects;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaseScenarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CaseScenarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseScenario
        [HttpGet]
        public async Task<ActionResult<List<CaseScenario>>> GetAll()
        {
            return await _context.CaseScenarios
                .Include(c => c.Patient)
                .Include(c => c.VitalSignsHistory)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CaseScenario>> Get(int id)
        {
            var scenario = await _context.CaseScenarios
                .Include(c => c.Patient)
                .Include(c => c.VitalSignsHistory)
                .Include(c => c.ActionLogs)
                .Include(c => c.TeacherObservations)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (scenario == null)
                return NotFound();

            return scenario;
        }

        // POST: api/CaseScenario
        [HttpPost]
        public async Task<ActionResult<CaseScenario>> Create(CaseScenario scenario)
        {
            _context.CaseScenarios.Add(scenario);
            await _context.SaveChangesAsync();

            return Ok(scenario);
        }

        [HttpPost("reset/{id}")]
        public async Task<IActionResult> ResetCase(int id)
        {
            var scenario = await _context.CaseScenarios
                .Include(c => c.VitalSignsHistory)
                .Include(c => c.ActionLogs)
                .Include(c => c.TeacherObservations)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (scenario == null)
                return NotFound();

            _context.VitalSigns.RemoveRange(
                scenario.VitalSignsHistory);

            _context.ActionLogs.RemoveRange(
                scenario.ActionLogs);

            _context.TeacherObservations.RemoveRange(
                scenario.TeacherObservations);

            // NEW BASELINE VITALS
            var baseline = new VitalSigns
            {
                CaseScenarioId = id,

                HeartRate = 85,

                SystolicPressure = 120,

                DiastolicPressure = 80,

                OxygenSaturation = 98,

                RespiratoryRate = 16,

                Temperature = 37.0,

                TimeStamp = DateTime.Now
            };

            _context.VitalSigns.Add(baseline);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            CaseScenario updatedCase)
        {
            if (id != updatedCase.Id)
            {
                return BadRequest();
            }

            var existingCase =
                await _context.CaseScenarios
                    .Include(c => c.Patient)
                    .FirstOrDefaultAsync(c => c.Id == id);

            if (existingCase == null)
            {
                return NotFound();
            }

            existingCase.Title =
                updatedCase.Title;

            if (existingCase.Patient != null &&
                updatedCase.Patient != null)
            {
                existingCase.Patient.FullName =
                    updatedCase.Patient.FullName;

                existingCase.Patient.Age =
                    updatedCase.Patient.Age;

                existingCase.Patient.Room =
                    updatedCase.Patient.Room;

                existingCase.Patient.AdmittingDiagnosis =
                    updatedCase.Patient
                        .AdmittingDiagnosis;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}