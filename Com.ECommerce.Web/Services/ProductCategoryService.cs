using Com.ECommerce.Web.Data;
using Com.ECommerce.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Com.ECommerce.Web.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly ECommerceDBContext _db;

        public ProductCategoryService(ECommerceDBContext context)

        {
            _db = context;
        }

        public Task<int> Create(ProductCategory productCategory)
        {
            _db.ProductCategory.Add(productCategory);
            return _db.SaveChangesAsync();

        }

        public async Task<int> Delete(int id)
        {
            var model = await GetById(id);
            _db.ProductCategory.Remove(model);
            return await _db.SaveChangesAsync();

        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await _db.ProductCategory.ToListAsync();
           
        }

        public async Task<ProductCategory> GetById(int id)
        {
            return  await _db.ProductCategory.FindAsync(id);
        }

        public Task<int> Update(ProductCategory productCategory)
        {
            _db.ProductCategory.Update(productCategory);
            return _db.SaveChangesAsync();
        }
    }
}    