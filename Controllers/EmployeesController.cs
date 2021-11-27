// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Rocket_Elevators_REST_API.Models;
// namespace Rocket_Elevators_REST_API.Controllers{
//   [Route("api/[controller]")]
//   [ApiController]
//   public class EmployeesController : ControllerBase{
//     private readonly ApplicationContext _context;
//     private readonly PostgreApplicationContext _context2;
//     public BuildingsController(ApplicationContext context,PostgreApplicationContext context2)
//     {
//       _context = context;
//       _context2 = context2;
//     }
//     [HttpGet("{id}/bonus3")]
//     public async Task<ActionResult<string>> getInterventionsForEmployee(int id){
//         var employee = await _context.employees.FindAsync(id);
//         var factInterventions = await _context2.fact_interventions.Where(f => f.employee_id == employee.id).ToListAsync();
//         var returnString = "";
//         for (var i = 0; i < factInterventions.Count; i++){
//             var building = await _context.buildings.FindAsync(factInterventions[i].building_id);
//             returnString = returnString + factInterventions[i].ToString() + building.ToString();

//         return null
//         }
//     }
//   }
// }