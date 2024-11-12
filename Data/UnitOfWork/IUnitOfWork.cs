using Findry.Data.Interfaces;

namespace Findry.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IUserRepository Users { get; }

        Task<int> CompleteAsync();
    }
}
