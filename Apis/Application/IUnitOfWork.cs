using Application.Interfaces.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {

        public IUserRepository UserRepository { get; }
        public IOrderRepository OrderRepository { get; }

        int SaveChange();
        public Task<int> SaveChangeAsync();
    }
}
