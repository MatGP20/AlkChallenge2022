using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlkChallenge_Disney.Data;
using AlkemyChallenge.Models;

namespace AlkChallenge_Disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroXPOSController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GeneroXPOSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GeneroXPOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroXPOS>>> GetGeneroXPOss()
        {
          if (_context.GeneroXPOss == null)
          {
              return NotFound();
          }
            return await _context.GeneroXPOss.ToListAsync();
        }

        // GET: api/GeneroXPOS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroXPOS>> GetGeneroXPOS(int id)
        {
          if (_context.GeneroXPOss == null)
          {
              return NotFound();
          }
            var generoXPOS = await _context.GeneroXPOss.FindAsync(id);

            if (generoXPOS == null)
            {
                return NotFound();
            }

            return generoXPOS;
        }

        // PUT: api/GeneroXPOS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneroXPOS(int id, GeneroXPOS generoXPOS)
        {
            if (id != generoXPOS.Id)
            {
                return BadRequest();
            }

            _context.Entry(generoXPOS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroXPOSExists(id))
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

        // POST: api/GeneroXPOS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneroXPOS>> PostGeneroXPOS(GeneroXPOS generoXPOS)
        {
          if (_context.GeneroXPOss == null)
          {
              return Problem("Entity set 'ApplicationDbContext.GeneroXPOss'  is null.");
          }
            _context.GeneroXPOss.Add(generoXPOS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneroXPOS", new { id = generoXPOS.Id }, generoXPOS);
        }

        // DELETE: api/GeneroXPOS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneroXPOS(int id)
        {
            if (_context.GeneroXPOss == null)
            {
                return NotFound();
            }
            var generoXPOS = await _context.GeneroXPOss.FindAsync(id);
            if (generoXPOS == null)
            {
                return NotFound();
            }

            _context.GeneroXPOss.Remove(generoXPOS);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneroXPOSExists(int id)
        {
            return (_context.GeneroXPOss?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
