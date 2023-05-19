using Application;
using Application.Interfaces.Repositories;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(AppDbContext dbContext,
            IOrderRepository orderRepository,
            IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IOrderRepository OrderRepository => _orderRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
