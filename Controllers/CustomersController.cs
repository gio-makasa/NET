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
    public class CustomersController : ControllerBase
    {
        private readonly FinalAPIContext _context;

        public CustomersController(FinalAPIContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _context.Customer.ToListAsync();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerDTO customer)
        {
            Customer c = new Customer();

            c.FirstName = customer.FirstName;
            c.LastName = customer.LastName;
            c.PID = customer.PID;

            _context.Customer.Add(c);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
