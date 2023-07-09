using Com.ECommerce.Web.Data;
using Com.ECommerce.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Com.ECommerce.Web.Services
{
    public class SelectlistService : ISelectlistService
    {
        private readonly ECommerceDBContext _service;

        public SelectlistService(ECommerceDBContext service)
        {
            _service = service;
        }
        public IEnumerable<Brand> Brand()
        {
            return  _service.Brand.ToList();
        }

        public IEnumerable<ProductCategory> ProductCategories()
        {
           return  _service.ProductCategory.ToList();
        }

        public IEnumerable<ProductSubCategory> ProductSubCategories()
        {
            return _service.ProductSubCategory.ToList();
        }
    }
}
