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
    public class EmployeeController : ControllerBase{

        private readonly ApplicationContext _context;
        private readonly PostgreApplicationContext _context2;

        public EmployeeController(ApplicationContext context, PostgreApplicationContext context2)
        {
            _context = context;
            _context2 = context2;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.employees.ToListAsync();
        }

        [HttpGet("{id}/bonus3")]
        public async Task<ActionResult<String>> GetSpecificEmployee(int id){

            var employee =  await _context.employees.FindAsync(id);
            var factInterventions = await _context2.fact_interventions.Where(c => c.employee_id == employee.id).ToListAsync();
            var returnString = "";
            if (employee == null)
            {
                return NotFound();
            }
            foreach(var factIntervention in factInterventions){
                returnString = returnString + factIntervention.ToString();
            }

            return returnString + " employee id: "+ employee.id;

        }
    }

}
    

