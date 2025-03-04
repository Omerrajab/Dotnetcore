﻿using Findry.Data.Context;
using Findry.Data.Interfaces;

namespace Findry.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(ApplicationDbContext context, IProductRepository productRepository, ICategoryRepository categories,IUserRepository users)
        {
            _context = context;
            Products = productRepository;
            Categories = categories;  
            Users = users;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
