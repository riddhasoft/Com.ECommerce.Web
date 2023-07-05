using Com.ECommerce.Web.Models;

namespace Com.ECommerce.Web.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetAll();
        
        Task<ProductCategory> GetById(int id);

        Task<int> Delete (int  id);

        Task<int> Update(ProductCategory productCategory);

        Task<int> Create(ProductCategory productCategory);    
    }
}
