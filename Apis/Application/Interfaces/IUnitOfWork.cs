using Application.Interfaces.Repositories;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {

        public ICustomerRepository CustomerRepository { get; }
        public IBaseUserRepository UserRepository { get; }
        public IDriverRepository DriverRepository { get; }
        public ILaundryOrderRepository OrderRepository { get; }
        public ISessionRepository SessionRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public IBatchRepository BatchRepository { get; }
        public IBuildingRepository BuildingRepository { get; }
        public IPaymentRepository PaymentRepository { get; }

        public int SaveChange();
        public Task<int> SaveChangeAsync();
    }
}
