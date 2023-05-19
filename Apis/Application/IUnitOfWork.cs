using Application.Interfaces.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {

        public IUserRepository UserRepository { get; }
        public IOrderRepository OrderRepository { get; }

        public Task<int> SaveChangeAsync();
    }
}
