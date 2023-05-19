using Application.Interfaces.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IOrderRepository ChemicalRepository { get; }

        public IUserRepository UserRepository { get; }

        public Task<int> SaveChangeAsync();
    }
}
