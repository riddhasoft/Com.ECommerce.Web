using Com.ECommerce.Web.Data;
using Com.ECommerce.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Com.ECommerce.Web.Services
{
    public class BrandService : IBrandService
    {
        private readonly ECommerceDBContext _context;

        public BrandService(ECommerceDBContext context)
        {

            _context = context;
        }

        public Task<int> Create(Brand brand)
        {
            _context.Brand.Add(brand);
            return _context.SaveChangesAsync();
        }


        public async Task<int> Delete(int id)
        {
            var model = await Get(id);
            _context.Brand.Remove(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brand>> Get()
        {
            return await _context.Brand.ToListAsync();
        }

        public Task<Brand> Get(int id)
        {
            return _context.Brand.Where(x => x.Id==id).FirstOrDefaultAsync();
        }

        public Task<int> Update(Brand brand)
        {
            _context.Brand.Update(brand);
            return _context.SaveChangesAsync();
        }
    }
}
