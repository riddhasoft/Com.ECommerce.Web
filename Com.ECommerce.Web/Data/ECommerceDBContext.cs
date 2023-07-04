using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Com.ECommerce.Web.Models;

namespace Com.ECommerce.Web.Data
{
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext (DbContextOptions<ECommerceDBContext> options)
            : base(options)
        {
        }

        public DbSet<Com.ECommerce.Web.Models.ProductCategory> ProductCategory { get; set; } = default!;
    }
}
