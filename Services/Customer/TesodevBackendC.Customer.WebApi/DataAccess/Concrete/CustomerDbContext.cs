using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TesodevBackendC.Customer.WebApi.Entities;

namespace TesodevBackendC.Customer.WebApi.DataAccess.Concrete
{
    public class CustomerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1481;initial Catalog=CBackendDb;User=sa;Password=622622aA.");
        }


        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customerr> Customerrs { get; set; }
    }
}
