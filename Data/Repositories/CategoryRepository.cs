
using Findry.Data.Interfaces;
using Findry.Data.Entities;
using Findry.Data.Context;

namespace Findry.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
