﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetC_.Data;
using ProjetC_.Models;

namespace ProjetC_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ProjetC_Context _context;

        public CategoriesController(ProjetC_Context context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategorie()
        {
          if (_context.Categorie == null)
          {
              return NotFound();
          }
            return await _context.Categorie.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> GetCategorie(int id)
        {
          if (_context.Categorie == null)
          {
              return NotFound();
          }
            var categorie = await _context.Categorie.FindAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }

            return categorie;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorie(int id, Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorie>> PostCategorie(Categorie categorie)
        {
          if (_context.Categorie == null)
          {
              return Problem("Entity set 'ProjetC_Context.Categorie'  is null.");
          }
            _context.Categorie.Add(categorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorie", new { id = categorie.Id }, categorie);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie(int id)
        {
            if (_context.Categorie == null)
            {
                return NotFound();
            }
            var categorie = await _context.Categorie.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            _context.Categorie.Remove(categorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorieExists(int id)
        {
            return (_context.Categorie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
