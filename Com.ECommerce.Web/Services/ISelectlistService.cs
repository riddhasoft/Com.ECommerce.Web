using Com.ECommerce.Web.Models;

namespace Com.ECommerce.Web.Services
{
    public interface ISelectlistService
    {
        IEnumerable<ProductCategory> ProductCategories();
        IEnumerable<ProductSubCategory> ProductSubCategories();
        IEnumerable<Brand> Brand();

    }
}
