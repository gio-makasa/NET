using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalAPI.EF;

namespace FinalAPI.Data
{
    public class FinalAPIContext : DbContext
    {
        public FinalAPIContext (DbContextOptions<FinalAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FinalAPI.EF.Product> Product { get; set; } = default!;
        public DbSet<FinalAPI.EF.Customer> Customer { get; set; } = default!;
        public DbSet<FinalAPI.EF.SoldProducts> SoldProducts { get; set; } = default!;
    }
}
