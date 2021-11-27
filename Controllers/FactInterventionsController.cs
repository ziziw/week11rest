using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;
using Microsoft.AspNetCore.JsonPatch;
namespace Rocket_Elevators_REST_API.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class FactInterventionsController : ControllerBase{
        private readonly PostgreApplicationContext _context;
        private readonly ApplicationContext _context2;
        public FactInterventionsController(PostgreApplicationContext context, ApplicationContext context2)
        {
            _context = context;
            _context2 = context2;
        }
        // GET: api/FactInterventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactIntervention>>> GetfactinterventionsS()
        {
            return await _context.fact_interventions.ToListAsync();
        }

        //GET from specific intervention
        [HttpGet("{id}/bonus1")]
        public async Task<ActionResult<String>> GetSpecificIntervention(int id)
        {
            var factIntervention =  await _context.fact_interventions.FindAsync(id);
            var building = await _context2.buildings.FindAsync(factIntervention.building_id);
            var address = await _context2.addresses.FindAsync(building.address_id);
            if (factIntervention == null)
            {
                return NotFound();
            }
            return "factIntervention start intervention:" + factIntervention.start_intervention + "\nfactIntervention stop intervention " + factIntervention.end_intervention + "\naddress: " +address.number_and_street;
        } 
        
        
    }
}