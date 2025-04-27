using ChartDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ChartDemo.Data
{
    public class DbContextSales : DbContext
    {
        public DbContextSales(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SalesEntity> SalesData { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
