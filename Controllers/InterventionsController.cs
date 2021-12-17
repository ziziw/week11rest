using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevators_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public InterventionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET all interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventions()
        {
            return await _context.interventions.ToListAsync();
        }

        // GET: api/Interventions/pending
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetinterventionsPending()
        {
            var findInterventions = await _context.interventions
                .Where(intervention => intervention.status == "Pending" && intervention.start_intervention == null).ToListAsync();

            return findInterventions;
        }

        // PUT: api/Interventions/5/InProgress
        // PUT: api/Interventions/5/Completed
        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<Intervention>> PutInterventionStatus(int id, string status)
        {
            var findIntervention = await _context.interventions.FindAsync(id);
            findIntervention.status = status;

            if (status == "InProgress")
            {
                findIntervention.start_intervention = DateTime.Now;
                await _context.SaveChangesAsync();
                return findIntervention;
            }

            if (status == "Completed")
            {
                findIntervention.end_intervention = DateTime.Now;
                await _context.SaveChangesAsync();
                return findIntervention;
            }

            return Ok("Invalid request");
        }
    }
}
