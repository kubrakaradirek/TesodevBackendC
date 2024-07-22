using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Domain.Entities;

namespace TesodevBackendC.Order.Persistence.Context
{
    public class OrderDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MONSTER\\MSSQLSERVERR;initial Catalog=OrderBCDb;integrated Security=true;User=sa;Password=622622aA.");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrderDetail> ProductOrderDetails { get; set; }
    }
}
