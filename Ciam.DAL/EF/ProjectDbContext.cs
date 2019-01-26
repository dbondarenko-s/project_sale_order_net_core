using Ciam.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Ciam.DAL.EF
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }

        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

        public DbSet<SalesStatus> SalesStatuses { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
            //base.Configuration.LazyLoadingEnabled = false;
        }
    }
}
