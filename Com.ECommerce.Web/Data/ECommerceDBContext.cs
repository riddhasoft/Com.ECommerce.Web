using Microsoft.EntityFrameworkCore;

namespace Com.ECommerce.Web.Data
{
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext (DbContextOptions<ECommerceDBContext> options)
            : base(options)
        {
        }

        public DbSet<Com.ECommerce.Web.Models.ProductCategory> ProductCategory { get; set; } = default!;

        public DbSet<Com.ECommerce.Web.Models.Product>? Product { get; set; }

        public DbSet<Com.ECommerce.Web.Models.ProductSubCategory>? ProductSubCategory { get; set; }

        public DbSet<Com.ECommerce.Web.Models.Brand>? Brand { get; set; }
    }
}
