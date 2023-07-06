using Com.ECommerce.Web.Data;
using Com.ECommerce.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Com.ECommerce.Web.Services
{
    public class ProductSubCategoryService : IProductSubCategoryService
    {
        private readonly ECommerceDBContext _db;

        public ProductSubCategoryService(ECommerceDBContext context)
        {
            _db = context;
        }
        public async Task<int> Create(ProductSubCategory productSubCategory)
        {
            _db.ProductSubCategory.Add(productSubCategory);
            return await _db.SaveChangesAsync();


        }

        public Task<int> Delete(int id)
        {
            var model = GetById(id);
            _db.Remove(model);
            return _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductSubCategory>> GetAll()
        {
            return await _db.ProductSubCategory.ToListAsync();
        }

        public async Task<ProductSubCategory> GetById(int id)
        {
            
           return await _db.ProductSubCategory.FindAsync(id);
        }

        public async Task<IEnumerable<ProductCategory>> ProductCategories()
        {

            return await _db.ProductCategory.ToListAsync();
        }

        public  async Task<int> Update(ProductSubCategory productSubCategory)
        {
            _db.ProductSubCategory.Update(productSubCategory);
            return await _db.SaveChangesAsync();
        }
    }
}
