using System;
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
    public class LeadsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LeadsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Leads/potential
        [HttpGet("potential")]
        public async Task<ActionResult<IEnumerable<Lead>>> GetleadsPotential()
        {
            List<Lead> finalLeads = new List<Lead>();

            var findLeads = await (from leads in _context.leads
                                   where leads.date_of_creation >= DateTime.Now.AddDays(-30)
                                   select leads).Distinct().ToListAsync();

            var findCustomers = await _context.customers.ToListAsync();

            foreach (var lead in findLeads)
            {
                bool isInside = false;
                foreach (var customer in findCustomers)
                {
                    if (lead.email == customer.email_of_the_company_contact)
                    {
                        isInside = true;
                    }
                }
                if (isInside == false)
                {
                    finalLeads.Add(lead);
                }
            }

            return finalLeads;
        }

        private bool LeadExists(int id)
        {
            return _context.leads.Any(e => e.id == id);
        }
    }
}
