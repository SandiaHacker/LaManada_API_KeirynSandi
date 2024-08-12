using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaManada_API_KeirynSandi.Models;

namespace LaManada_API_KeirynSandi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetCaresController : ControllerBase
    {
        private readonly LaManadaContext _context;

        public PetCaresController(LaManadaContext context)
        {
            _context = context;
        }

        // GET: api/PetCares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetCare>>> GetPetCares()
        {
            return await _context.PetCares.ToListAsync();
        }

        // GET: api/PetCares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetCare>> GetPetCare(int id)
        {
            var petCare = await _context.PetCares.FindAsync(id);

            if (petCare == null)
            {
                return NotFound();
            }

            return petCare;
        }

        // PUT: api/PetCares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetCare(int id, PetCare petCare)
        {
            if (id != petCare.PetCareId)
            {
                return BadRequest();
            }

            _context.Entry(petCare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetCareExists(id))
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

        // POST: api/PetCares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PetCare>> PostPetCare(PetCare petCare)
        {
            _context.PetCares.Add(petCare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetCare", new { id = petCare.PetCareId }, petCare);
        }

        // DELETE: api/PetCares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetCare(int id)
        {
            var petCare = await _context.PetCares.FindAsync(id);
            if (petCare == null)
            {
                return NotFound();
            }

            _context.PetCares.Remove(petCare);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetCareExists(int id)
        {
            return _context.PetCares.Any(e => e.PetCareId == id);
        }
    }
}
