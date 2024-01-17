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
    public class ProductsController : ControllerBase
    {
        private readonly FinalAPIContext _context;

        public ProductsController(FinalAPIContext context)
        {
            _context = context;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO product)
        {
            try
            {
                var p = await _context.Product.FindAsync(id);
                if (p == null)
                    return NotFound();
                p.Name = product.Name;
                p.Description = product.Description;
                p.Type = product.Type;
                p.Policy = product.Policy;
                p.Amount = 10 * ((int)product.Policy + 1) * ((int)product.Category + 1) * ((int)product.Type + 1);
                p.Category = product.Category;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO product)
        {
            if (product == null)
                return BadRequest();

            Product p = new Product();

            p.Name = product.Name;
            p.Description = product.Description;
            p.Type = product.Type;
            p.Policy = product.Policy;
            p.Amount = 10 * ((int)product.Policy + 1) * ((int)product.Category + 1) * ((int)product.Type + 1);
            p.Category = product.Category;

            _context.Product.Add(p);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
