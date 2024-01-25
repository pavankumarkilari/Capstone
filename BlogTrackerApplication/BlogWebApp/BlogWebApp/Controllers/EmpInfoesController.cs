using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpInfoesController : ControllerBase
    {
        private readonly CapstoneProjDb1Context _context;

        public EmpInfoesController(CapstoneProjDb1Context context)
        {
            _context = context;
        }

        // GET: api/EmpInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpInfo>>> GetEmpInfos()
        {
            if (_context.EmpInfos == null)
            {
                return NotFound();
            }
            return await _context.EmpInfos.ToListAsync();
        }

        // GET: api/EmpInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpInfo>> GetEmpInfo(string id)
        {
            if (_context.EmpInfos == null)
            {
                return NotFound();
            }
            var empInfo = await _context.EmpInfos.FindAsync(id);

            if (empInfo == null)
            {
                return NotFound();
            }

            return empInfo;
        }

        // PUT: api/EmpInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpInfo(string id, EmpInfo empInfo)
        {
            if (id != empInfo.EmailId)
            {
                return BadRequest();
            }

            _context.Entry(empInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpInfoExists(id))
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

        // POST: api/EmpInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpInfo>> PostEmpInfo(EmpInfo empInfo)
        {
            if (_context.EmpInfos == null)
            {
                return Problem("Entity set 'CapstoneProjDb1Context.EmpInfos'  is null.");
            }
            _context.EmpInfos.Add(empInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpInfoExists(empInfo.EmailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpInfo", new { id = empInfo.EmailId }, empInfo);
        }

        // DELETE: api/EmpInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpInfo(string id)
        {
            if (_context.EmpInfos == null)
            {
                return NotFound();
            }
            var empInfo = await _context.EmpInfos.FindAsync(id);
            if (empInfo == null)
            {
                return NotFound();
            }

            _context.EmpInfos.Remove(empInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpInfoExists(string id)
        {
            return (_context.EmpInfos?.Any(e => e.EmailId == id)).GetValueOrDefault();
        }
    }
}