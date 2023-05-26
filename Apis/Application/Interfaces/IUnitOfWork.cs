using Application.Interfaces.Repositories;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {

        public IUserRepository UserRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ITimeSlotRepository TimeSlotRepository { get; }
        public IStoreReportRepository StoreReportRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public IServiceRepository ServiceRepository { get; }

        public int SaveChange();
        public Task<int> SaveChangeAsync();
    }
}
