using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminInfoesController : ControllerBase
    {
        private readonly CapstoneProjDb1Context _context;

        public AdminInfoesController(CapstoneProjDb1Context context)
        {
            _context = context;
        }

        // GET: api/AdminInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminInfo>>> GetAdminInfos()
        {
            if (_context.AdminInfos == null)
            {
                return NotFound();
            }
            return await _context.AdminInfos.ToListAsync();
        }

        // GET: api/AdminInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminInfo>> GetAdminInfo(string id)
        {
            if (_context.AdminInfos == null)
            {
                return NotFound();
            }
            var adminInfo = await _context.AdminInfos.FindAsync(id);

            if (adminInfo == null)
            {
                return NotFound();
            }

            return adminInfo;
        }

        // PUT: api/AdminInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminInfo(string id, AdminInfo adminInfo)
        {
            if (id != adminInfo.EmailId)
            {
                return BadRequest();
            }

            _context.Entry(adminInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminInfoExists(id))
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

        // POST: api/AdminInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminInfo>> PostAdminInfo(AdminInfo adminInfo)
        {
            if (_context.AdminInfos == null)
            {
                return Problem("Entity set 'CapstoneProjDb1Context.AdminInfos'  is null.");
            }
            _context.AdminInfos.Add(adminInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminInfoExists(adminInfo.EmailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdminInfo", new { id = adminInfo.EmailId }, adminInfo);
        }

        // DELETE: api/AdminInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminInfo(string id)
        {
            if (_context.AdminInfos == null)
            {
                return NotFound();
            }
            var adminInfo = await _context.AdminInfos.FindAsync(id);
            if (adminInfo == null)
            {
                return NotFound();
            }

            _context.AdminInfos.Remove(adminInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminInfoExists(string id)
        {
            return (_context.AdminInfos?.Any(e => e.EmailId == id)).GetValueOrDefault();
        }
    }
}