using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battery>>> Getbatteries()
        {
            return await _context.batteries.ToListAsync();
        }

        // GET: api/Batteries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Battery>> GetBattery(int id)
        {
            var battery = await _context.batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery;
        }

        // GET: api/Batteries/5/status
        [HttpGet("{id}/status")]
        public async Task<ActionResult<String>> GetBatteryStatus(int id)
        {
            var battery = await _context.batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery.status;
        }

        // PUT: api/Batteries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattery(int id, Battery battery)
        {
            if (id != battery.id)
            {
                return BadRequest();
            }

            _context.Entry(battery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PATCH: api/Batteries/5/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> PatchBatteryStatus(int id, [FromBody]JsonPatchDocument<Battery> batteryPatch)
        {
            var battery = await _context.batteries.FindAsync(id);
            batteryPatch.ApplyTo(battery);
            return Content("Successfully updated the status of battery " + battery.id + " to " + battery.status);
        }

        // POST: api/Batteries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Battery>> PostBattery(Battery battery)
        {
            _context.batteries.Add(battery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattery", new { id = battery.id }, battery);
        }

        // DELETE: api/Batteries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBattery(int id)
        {
            var battery = await _context.batteries.FindAsync(id);
            if (battery == null)
            {
                return NotFound();
            }

            _context.batteries.Remove(battery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BatteryExists(int id)
        {
            return _context.batteries.Any(e => e.id == id);
        }
    }
}
