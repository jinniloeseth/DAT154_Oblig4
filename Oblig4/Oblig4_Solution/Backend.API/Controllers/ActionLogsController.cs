using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Objects;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ActionLogsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ActionLogs
        [HttpGet]
        public async Task<ActionResult<List<ActionLog>>> GetAll()
        {
            return await _context.ActionLogs
                .Include(a => a.CaseScenario)
                .ToListAsync();
        }

        // POST: api/ActionLogs
        [HttpPost]
        public async Task<ActionResult<ActionLog>> Create(ActionLog actionLog)
        {

            _context.ActionLogs.Add(actionLog);

            await _context.SaveChangesAsync();

            return Ok(actionLog);
        }
    }
}