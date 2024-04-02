using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test001.Data;
using test001.Model;

namespace test001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DessertsController : ControllerBase
    {
        private readonly DessertsContext _context;

        public DessertsController(DessertsContext context)
        {
            _context = context;
        }

        // GET: api/Desserts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desserts>>> GetDesserts()
        {
            return await _context.Desserts.ToListAsync();
        }

        // GET: api/Desserts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desserts>> GetDesserts(int id)
        {
            var desserts = await _context.Desserts.FindAsync(id);

            if (desserts == null)
            {
                return NotFound();
            }

            return desserts;
        }

        // PUT: api/Desserts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesserts(int id, Desserts desserts)
        {
            if (id != desserts.id)
            {
                return BadRequest();
            }

            _context.Entry(desserts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DessertsExists(id))
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

        // POST: api/Desserts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Desserts>> PostDesserts(Desserts desserts)
        {
            _context.Desserts.Add(desserts);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DessertsExists(desserts.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDesserts", new { id = desserts.id }, desserts);
        }

        // DELETE: api/Desserts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesserts(int id)
        {
            var desserts = await _context.Desserts.FindAsync(id);
            if (desserts == null)
            {
                return NotFound();
            }

            _context.Desserts.Remove(desserts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DessertsExists(int id)
        {
            return _context.Desserts.Any(e => e.id == id);
        }
    }
}
