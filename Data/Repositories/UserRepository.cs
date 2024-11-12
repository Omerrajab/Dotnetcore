using Findry.Data.Context;
using Findry.Data.Entities;
using Findry.Data.Interfaces;

namespace Findry.Data.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}
