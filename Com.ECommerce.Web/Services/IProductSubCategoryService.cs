using Com.ECommerce.Web.Models;

namespace Com.ECommerce.Web.Services
{
    public interface IProductSubCategoryService
    {
        Task<IEnumerable<ProductSubCategory>> GetAll();

        Task<ProductSubCategory> GetById(int id);

        Task<int> Delete(int id);

        Task<int> Update(ProductSubCategory productSubCategory);

        Task<int> Create(ProductSubCategory productSubCategory);

        Task<IEnumerable<ProductCategory>> ProductCategories();
    }
}
