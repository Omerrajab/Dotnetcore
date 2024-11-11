using Findry.Data.Entities;
using Findry.Data.UnitOfWork;

namespace Findry.Services
{
   
        public class CategoryService
        {
            private readonly IUnitOfWork _unitOfWork;

            public CategoryService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
            {
                return await _unitOfWork.Categories.GetAllAsync();
            }

            public async Task<Category> GetCategoryByIdAsync(int id)
            {
                return await _unitOfWork.Categories.GetByIdAsync(id);
            }

            public async Task AddCategoryAsync(Category category)
            {
                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.CompleteAsync();
            }

            public async Task UpdateCategoryAsync(Category category)
            {
                _unitOfWork.Categories.Update(category);
                await _unitOfWork.CompleteAsync();
            }

            public async Task DeleteCategoryAsync(int id)
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(id);
                if (category != null)
                {
                    _unitOfWork.Categories.Delete(category);
                    await _unitOfWork.CompleteAsync();
                }
            }
        }
}
