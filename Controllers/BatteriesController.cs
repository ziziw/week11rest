using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Rocket_Elevators_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BatteriesController(ApplicationContext context)
        {
            _context = context;
        }

        //-----------------------------------------------------
        // ADDED ENDPOINTS:
        //-----------------------------------------------------


        // GET: api/Batteries/5/status
        // get specific battery's status
        [HttpGet("{id}/status")]
        public async Task<ActionResult<String>> GetBatteryStatus(int id)
        {
            var battery = await _context.batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return "Battery " + battery.id + "'s status is: " + battery.status;
        }

        // PATCH: api/Batteries/5
        // update status (or any single field) of a battery using the following format:
            // [{"op": "replace", "path": "/status", "value": "Offline"}]
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBatteryStatus(int id, [FromBody]JsonPatchDocument<Battery> batteryPatch)
        {
            var battery = await _context.batteries.FindAsync(id);
            batteryPatch.ApplyTo(battery);

            await _context.SaveChangesAsync();

            return Content("Successfully updated battery " + battery.id);
        }


        //-----------------------------------------------------
        // END
        //-----------------------------------------------------

        private bool BatteryExists(int id)
        {
            return _context.batteries.Any(e => e.id == id);
        }
    }
}
