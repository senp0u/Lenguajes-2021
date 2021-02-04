using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk_SupportAPI.Models;

namespace HelpDesk_SupportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DB_A6E1ED_lenguajesContext _context;

        public EmployeeController()
        {
            _context = new DB_A6E1ED_lenguajesContext();
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/Employee/GetEmployeeSupervisor
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeSupervisor()
        {
            return await _context.Employee.Where(i => i.IsSupervisor == true).ToListAsync();
        }

        // GET: api/Employee/GetEmployeesNonSupervisor
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesNonSupervisor()
        {
            return await _context.Employee.Where(i => i.IsSupervisor == false).ToListAsync();
        }


        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }

        [Route("[action]/email={email}&password={password}")]
        [HttpGet]
        public Employee GetEmployeeToAuthenticate(string email, string password)
        {
            var employee = _context.Employee.Where(a => a.Email.Equals(email) && a.Password.Equals(password)).Single();

            return employee;
        }
    }
}
