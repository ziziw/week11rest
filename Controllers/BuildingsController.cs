using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevators_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly PostgreApplicationContext _context2;

        public BuildingsController(ApplicationContext context,PostgreApplicationContext context2)
        {
            _context = context;
            _context2 = context2;
        }

        // GET: api/Buildings/intervention
        // find buildings with intervention
        [HttpGet("intervention")]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildingsIntervention()
        {
            var findBuildings = (from buildings in _context.buildings
                                 join batteries in _context.batteries on buildings.id equals batteries.building_id
                                 join columns in _context.columns on batteries.id equals columns.battery_id
                                 join elevators in _context.elevators on columns.id equals elevators.column_id
                                 where elevators.status == "Intervention" || columns.status == "Intervention" || batteries.status == "Intervention"
                                 select buildings).Distinct();
            return await findBuildings.ToListAsync();
        }
        
        // GET: api/Buildings/bonus2
        // 2nd query in graphql done here
        [HttpGet("{id}/bonus2")]
        public async Task<ActionResult<string>> getInterventionForBuilding(int id){
            var building = await _context.buildings.FindAsync(id);
        
            var factInterventions = _context2.fact_interventions.Where(f => f.building_id == building.id).ToListAsync();
            var customer = await _context.customers.FindAsync(id);
            var returnString = "";
            foreach(var factIntervention in await factInterventions){
                returnString = returnString + factIntervention.ToString();
            }
            return returnString + "Customer ID: " + customer.id;

        }

        private bool BuildingExists(int id)
        {
            return _context.buildings.Any(e => e.id == id);
        }
    }
}
