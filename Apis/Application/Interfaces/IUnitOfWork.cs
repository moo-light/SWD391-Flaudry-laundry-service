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
        public IBatchRepository BatchRepository { get; }
        public IBuildingRepository BuildingRepository { get; }
        public IDriverReportRepository DriverReportRepository { get; }
        public IPackageRepository PackageRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IRoleRepository RoleRepository { get; }

        public int SaveChange();
        public Task<int> SaveChangeAsync();
    }
}
