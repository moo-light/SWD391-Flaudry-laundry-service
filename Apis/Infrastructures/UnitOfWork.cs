﻿using Application;
using Application.Interfaces.Repositories;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _chemicalRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(AppDbContext dbContext,
            IOrderRepository chemicalRepository,
            IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _chemicalRepository = chemicalRepository;
            _userRepository = userRepository;
        }
        public IOrderRepository ChemicalRepository => _chemicalRepository;

        public IUserRepository UserRepository => _userRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
