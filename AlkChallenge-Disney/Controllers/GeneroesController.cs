﻿using System;
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
    public class GeneroesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GeneroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Generoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
        {
          if (_context.Generos == null)
          {
              return NotFound();
          }
            return await _context.Generos.ToListAsync();
        }

        // GET: api/Generoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> GetGenero(int id)
        {
          if (_context.Generos == null)
          {
              return NotFound();
          }
            var genero = await _context.Generos.FindAsync(id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        // PUT: api/Generoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenero(int id, Genero genero)
        {
            if (id != genero.Id)
            {
                return BadRequest();
            }

            _context.Entry(genero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroExists(id))
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

        // POST: api/Generoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genero>> PostGenero(Genero genero)
        {
          if (_context.Generos == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Generos'  is null.");
          }
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenero", new { id = genero.Id }, genero);
        }

        // DELETE: api/Generoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenero(int id)
        {
            if (_context.Generos == null)
            {
                return NotFound();
            }
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            _context.Generos.Remove(genero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneroExists(int id)
        {
            return (_context.Generos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
