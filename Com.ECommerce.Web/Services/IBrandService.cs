using Com.ECommerce.Web.Models;

namespace Com.ECommerce.Web.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> Get();

        Task<Brand> Get(int id);

        Task<int> Delete(int id);

        Task<int> Update(Brand brand);

        Task<int> Create(Brand brand);
    }
}
