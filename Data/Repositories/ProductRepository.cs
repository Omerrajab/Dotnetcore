using Findry.Data.Context;
using Findry.Data.Entities;
using Findry.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Findry.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
    }
}
