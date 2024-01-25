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
    public class BlogInfoesController : ControllerBase
    {
        private readonly CapstoneProjDb1Context _context;

        public BlogInfoesController(CapstoneProjDb1Context context)
        {
            _context = context;
        }

        // GET: api/BlogInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogInfo>>> GetBlogInfos()
        {
            if (_context.BlogInfos == null)
            {
                return NotFound();
            }
            return await _context.BlogInfos.ToListAsync();
        }

        // GET: api/BlogInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogInfo>> GetBlogInfo(int id)
        {
            if (_context.BlogInfos == null)
            {
                return NotFound();
            }
            var blogInfo = await _context.BlogInfos.FindAsync(id);

            if (blogInfo == null)
            {
                return NotFound();
            }

            return blogInfo;
        }

        // PUT: api/BlogInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogInfo(int id, BlogInfo blogInfo)
        {
            if (id != blogInfo.BlogId)
            {
                return BadRequest();
            }

            _context.Entry(blogInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogInfoExists(id))
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

        // POST: api/BlogInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogInfo>> PostBlogInfo(BlogInfo blogInfo)
        {
            if (_context.BlogInfos == null)
            {
                return Problem("Entity set 'CapstoneProjDb1Context.BlogInfos'  is null.");
            }
            _context.BlogInfos.Add(blogInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BlogInfoExists(blogInfo.BlogId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBlogInfo", new { id = blogInfo.BlogId }, blogInfo);
        }

        // DELETE: api/BlogInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogInfo(int id)
        {
            if (_context.BlogInfos == null)
            {
                return NotFound();
            }
            var blogInfo = await _context.BlogInfos.FindAsync(id);
            if (blogInfo == null)
            {
                return NotFound();
            }

            _context.BlogInfos.Remove(blogInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogInfoExists(int id)
        {
            return (_context.BlogInfos?.Any(e => e.BlogId == id)).GetValueOrDefault();
        }
    }
}