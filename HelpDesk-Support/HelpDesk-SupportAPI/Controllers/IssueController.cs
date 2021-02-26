using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk_SupportAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace HelpDesk_SupportAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly DB_A6E1ED_lenguajesContext _context;

        public IssueController()
        {
            _context = new DB_A6E1ED_lenguajesContext();
        }

        // GET: api/Issue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssue()
        {
            return await _context.Issue.Include(i => i.Service).ToListAsync();
        }

        // GET: api/Issue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var issue = await _context.Issue.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

        // PUT: api/Issue/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssue(int id, Issue issue)
        {
            if (id != issue.ReportNumber)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
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

        //PUT: api/Issue/issue=#&employee=#
        [HttpPut]
        public IActionResult PutAssignEmployee(Issue issue)
        {

            int result = _context.Database.ExecuteSqlRaw("AssignEmployee {0}, {1}, {2}",
                                issue.ReportNumber,
                                issue.EmployeeId,
                                issue.SupervisorId);
            if (result == 0)
            {
                throw new OperationCanceledException();
            }

            return Ok(result);
        }

        // POST: api/Issue
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       // [EnableCors("AllPolicy")]
        [HttpPost]
        public async Task<ActionResult<Boolean>> PostIssue([FromBody]Issue issue)
        {
            try
            {
                issue.CreateDate = DateTime.Now;
                issue.ReportDate = DateTime.Now;
                _context.Issue.Add(issue);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(false); ;
            }
            return Ok(true);
        }

        // DELETE: api/Issue/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Issue>> DeleteIssue(int id)
        {
            var issue = await _context.Issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.Issue.Remove(issue);
            await _context.SaveChangesAsync();

            return issue;
        }

        private bool IssueExists(int id)
        {
            return _context.Issue.Any(e => e.ReportNumber == id);
        }
    }
}
