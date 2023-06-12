using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly ILaundryOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBaseUserRepository _baseUserRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ISessionRepository _timeSlotRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IPaymentRepository _paymentRepository;

        public UnitOfWork(AppDbContext dbContext,
                          ILaundryOrderRepository orderRepository,
                          ICustomerRepository userRepository,
                          ISessionRepository timeSlotRepository,
                          IStoreRepository storeRepository,
                          IServiceRepository serviceRepository,
                          IBatchRepository batchRepository,
                          IBuildingRepository buildingRepository,
                          IPaymentRepository paymentRepository,
                          IDriverRepository driverRepository,
                          IBaseUserRepository baseUserRepository)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _customerRepository = userRepository;
            _timeSlotRepository = timeSlotRepository;
            _storeRepository = storeRepository;
            _serviceRepository = serviceRepository;
            _batchRepository = batchRepository;
            _buildingRepository = buildingRepository;
            _paymentRepository = paymentRepository;
            _driverRepository = driverRepository;
            _baseUserRepository = baseUserRepository;
        }

        public ICustomerRepository CustomerRepository => _customerRepository;
        public ILaundryOrderRepository OrderRepository => _orderRepository;
        public ISessionRepository SessionRepository => _timeSlotRepository;


        public IStoreRepository StoreRepository => _storeRepository;

        public IServiceRepository ServiceRepository => _serviceRepository;

        public IBatchRepository BatchRepository => _batchRepository;

        public IBuildingRepository BuildingRepository => _buildingRepository;


        public IPaymentRepository PaymentRepository => _paymentRepository;

        public IBaseUserRepository UserRepository => _baseUserRepository;

        public IDriverRepository DriverRepository => _driverRepository;

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
