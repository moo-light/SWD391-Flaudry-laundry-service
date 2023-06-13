using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly ILaundryOrderRepository _orderRepository;
        private readonly ICustomerRepository _userRepository;
        private readonly ISessionRepository _timeSlotRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderInBatchRepository _orderInBatchRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IDriverRepository _driverRepository;
        public UnitOfWork(AppDbContext dbContext,
                          ILaundryOrderRepository orderRepository,
                          ICustomerRepository userRepository,
                          ISessionRepository timeSlotRepository,
                          IStoreRepository storeRepository,
                          IServiceRepository serviceRepository,
                          IBatchRepository batchRepository,
                          IBuildingRepository buildingRepository,
                          IPaymentRepository paymentRepository,
                          IOrderInBatchRepository orderInBatchRepository,
                          IOrderDetailRepository orderDetailRepository,
                          IDriverRepository driverRepository
            )

        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _timeSlotRepository = timeSlotRepository;
            _storeRepository = storeRepository;
            _serviceRepository = serviceRepository;
            _batchRepository = batchRepository;
            _buildingRepository = buildingRepository;
            _paymentRepository = paymentRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderInBatchRepository = orderInBatchRepository;
            _driverRepository = driverRepository;
        }

        public ICustomerRepository CustomerRepository => _userRepository;
        public ILaundryOrderRepository OrderRepository => _orderRepository;
        public ISessionRepository TimeSlotRepository => _timeSlotRepository;
        public IStoreRepository StoreRepository => _storeRepository;

        public IServiceRepository ServiceRepository => _serviceRepository;

        public IBatchRepository BatchRepository => _batchRepository;

        public IBuildingRepository BuildingRepository => _buildingRepository;

        public IPaymentRepository PaymentRepository => _paymentRepository;

        public IDriverRepository DriverRepository => _driverRepository;

        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;

        public IOrderInBatchRepository OrderInBatchRepository => _orderInBatchRepository;

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
