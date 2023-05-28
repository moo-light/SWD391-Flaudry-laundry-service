using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly IStoreReportRepository _storeReportRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IDriverReportRepository _driverReportRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IRoleRepository _roleRepository;

        public UnitOfWork(AppDbContext dbContext,
                          IOrderRepository orderRepository,
                          IUserRepository userRepository,
                          ITimeSlotRepository timeSlotRepository,
                          IStoreRepository storeRepository,
                          IServiceRepository serviceRepository,
                          IStoreReportRepository storeReportRepository,
                          IBatchRepository batchRepository,
                          IBuildingRepository buildingRepository,
                          IDriverReportRepository driverReportRepository,
                          IPackageRepository packageRepository,
                          IPaymentRepository paymentRepository,
                          IRoleRepository roleRepository)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _timeSlotRepository = timeSlotRepository;
            _storeRepository = storeRepository;
            _serviceRepository = serviceRepository;
            _storeReportRepository = storeReportRepository;
            _batchRepository = batchRepository;
            _buildingRepository = buildingRepository;
            _driverReportRepository = driverReportRepository;
            _packageRepository = packageRepository;
            _paymentRepository = paymentRepository;
            _roleRepository = roleRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IOrderRepository OrderRepository => _orderRepository;
        public ITimeSlotRepository TimeSlotRepository => _timeSlotRepository;

        public IStoreReportRepository StoreReportRepository => _storeReportRepository;

        public IStoreRepository StoreRepository => _storeRepository;

        public IServiceRepository ServiceRepository => _serviceRepository;

        public IBatchRepository BatchRepository => _batchRepository;

        public IBuildingRepository BuildingRepository => _buildingRepository;

        public IDriverReportRepository DriverReportRepository => _driverReportRepository;

        public IPackageRepository PackageRepository => _packageRepository;

        public IPaymentRepository PaymentRepository => _paymentRepository;

        public IRoleRepository RoleRepository => _roleRepository;

        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
