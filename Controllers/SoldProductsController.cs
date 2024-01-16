using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalAPI.Data;
using FinalAPI.EF;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldProductsController : ControllerBase
    {
        private readonly FinalAPIContext _context;

        public SoldProductsController(FinalAPIContext context)
        {
            _context = context;
        }

        // GET: api/SoldProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoldProducts>>> GetSoldProducts()
        {
            return await _context.SoldProducts.ToListAsync();
        }

        // GET: api/SoldProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoldProducts>> GetSoldProducts(int id)
        {
            var soldProducts = await _context.SoldProducts.FindAsync(id);

            if (soldProducts == null)
            {
                return NotFound();
            }

            return soldProducts;
        }

        // PUT: api/SoldProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoldProducts(int id, SoldProducts soldProducts)
        {
            if (id != soldProducts.Id)
            {
                return BadRequest();
            }

            _context.Entry(soldProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoldProductsExists(id))
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

        // POST: api/SoldProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoldProducts>> PostSoldProducts(SoldProducts soldProducts)
        {
            _context.SoldProducts.Add(soldProducts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoldProducts", new { id = soldProducts.Id }, soldProducts);
        }

        // DELETE: api/SoldProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoldProducts(int id)
        {
            var soldProducts = await _context.SoldProducts.FindAsync(id);
            if (soldProducts == null)
            {
                return NotFound();
            }

            _context.SoldProducts.Remove(soldProducts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoldProductsExists(int id)
        {
            return _context.SoldProducts.Any(e => e.Id == id);
        }
    }
}
