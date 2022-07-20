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
    public class PersonajeXPOSController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonajeXPOSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonajeXPOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonajeXPOS>>> GetPersonajeXPOss()
        {
          if (_context.PersonajeXPOss == null)
          {
              return NotFound();
          }
            return await _context.PersonajeXPOss.ToListAsync();
        }

        // GET: api/PersonajeXPOS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonajeXPOS>> GetPersonajeXPOS(int id)
        {
          if (_context.PersonajeXPOss == null)
          {
              return NotFound();
          }
            var personajeXPOS = await _context.PersonajeXPOss.FindAsync(id);

            if (personajeXPOS == null)
            {
                return NotFound();
            }

            return personajeXPOS;
        }

        // PUT: api/PersonajeXPOS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonajeXPOS(int id, PersonajeXPOS personajeXPOS)
        {
            if (id != personajeXPOS.Id)
            {
                return BadRequest();
            }

            _context.Entry(personajeXPOS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonajeXPOSExists(id))
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

        // POST: api/PersonajeXPOS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonajeXPOS>> PostPersonajeXPOS(PersonajeXPOS personajeXPOS)
        {
          if (_context.PersonajeXPOss == null)
          {
              return Problem("Entity set 'ApplicationDbContext.PersonajeXPOss'  is null.");
          }
            _context.PersonajeXPOss.Add(personajeXPOS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonajeXPOS", new { id = personajeXPOS.Id }, personajeXPOS);
        }

        // DELETE: api/PersonajeXPOS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonajeXPOS(int id)
        {
            if (_context.PersonajeXPOss == null)
            {
                return NotFound();
            }
            var personajeXPOS = await _context.PersonajeXPOss.FindAsync(id);
            if (personajeXPOS == null)
            {
                return NotFound();
            }

            _context.PersonajeXPOss.Remove(personajeXPOS);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonajeXPOSExists(int id)
        {
            return (_context.PersonajeXPOss?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
