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
    public class PeliculaSeriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PeliculaSeriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PeliculaSeries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeliculaSerie>>> GetPeliculaSeries()
        {
          if (_context.PeliculaSeries == null)
          {
              return NotFound();
          }
            return await _context.PeliculaSeries.ToListAsync();
        }

        // GET: api/PeliculaSeries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculaSerie>> GetPeliculaSerie(int id)
        {
          if (_context.PeliculaSeries == null)
          {
              return NotFound();
          }
            var peliculaSerie = await _context.PeliculaSeries.FindAsync(id);

            if (peliculaSerie == null)
            {
                return NotFound();
            }

            return peliculaSerie;
        }

        // PUT: api/PeliculaSeries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeliculaSerie(int id, PeliculaSerie peliculaSerie)
        {
            if (id != peliculaSerie.Id)
            {
                return BadRequest();
            }

            _context.Entry(peliculaSerie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaSerieExists(id))
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

        // POST: api/PeliculaSeries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PeliculaSerie>> PostPeliculaSerie(PeliculaSerie peliculaSerie)
        {
          if (_context.PeliculaSeries == null)
          {
              return Problem("Entity set 'ApplicationDbContext.PeliculaSeries'  is null.");
          }
            _context.PeliculaSeries.Add(peliculaSerie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeliculaSerie", new { id = peliculaSerie.Id }, peliculaSerie);
        }

        // DELETE: api/PeliculaSeries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeliculaSerie(int id)
        {
            if (_context.PeliculaSeries == null)
            {
                return NotFound();
            }
            var peliculaSerie = await _context.PeliculaSeries.FindAsync(id);
            if (peliculaSerie == null)
            {
                return NotFound();
            }

            _context.PeliculaSeries.Remove(peliculaSerie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeliculaSerieExists(int id)
        {
            return (_context.PeliculaSeries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
