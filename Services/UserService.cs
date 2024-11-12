using Findry.Data.Entities;
using Findry.Data.UnitOfWork;

namespace Findry.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> RegisterUserAsync(User newUser)
        {
            if (await _unitOfWork.Users.ExistsAsync(u => u.Email == newUser.Email))
            {
                return false; // User already exists
            }

            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
