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

        public BuildingsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Buildings/intervention
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

        private bool BuildingExists(int id)
        {
            return _context.buildings.Any(e => e.id == id);
        }
    }
}
