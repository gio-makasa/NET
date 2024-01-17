using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalAPI.Data;
using FinalAPI.EF;
using FinalAPI.Models;

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
            return await _context.SoldProducts.Include(e => e.Product).Include(e => e.Customer).ToListAsync();
        }

        // PUT: api/SoldProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoldProducts(int id, SoldProductsDTO soldProducts)
        {
            try
            {
                var s = await _context.SoldProducts.FindAsync(id);
                if (s == null)
                    return NotFound();
                s.ProductId = soldProducts.ProductId;
                s.CustomerId = soldProducts.CustomerId;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }

            return NoContent();
        }

        // POST: api/SoldProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoldProducts>> PostSoldProducts(SoldProductsDTO soldProducts)
        {
            SoldProducts s = new SoldProducts();

            s.ProductId = soldProducts.ProductId;
            s.CustomerId = soldProducts.CustomerId;

            _context.SoldProducts.Add(s);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
