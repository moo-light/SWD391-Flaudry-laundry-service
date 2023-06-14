using Application.Interfaces.Repositories;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {

        public ICustomerRepository CustomerRepository { get; } //r
        //public IBaseUserRepository UserRepository { get; } //?
        public IDriverRepository DriverRepository { get; } //r
        public ILaundryOrderRepository OrderRepository { get; } //r
        public ISessionRepository TimeSlotRepository { get; } //r
        public IStoreRepository StoreRepository { get; } //r 
        public IOrderDetailRepository OrderDetailRepository { get; } //r
        public IBatchRepository BatchRepository { get; } //r
        public IBuildingRepository BuildingRepository { get; } //r
        public IPaymentRepository PaymentRepository { get; } //r
        public ICustomerRepository CustomerRepository { get; }
        public IBaseUserRepository UserRepository { get; }
        public IDriverRepository DriverRepository { get; }
        public ILaundryOrderRepository OrderRepository { get; }
        public ISessionRepository SessionRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public IOrderInBatchRepository OrderInBatchRepository { get; }

        public int SaveChange();
        public Task<int> SaveChangeAsync();
    }
}
