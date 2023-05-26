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

        public UnitOfWork(AppDbContext dbContext,
                          IOrderRepository orderRepository,
                          IUserRepository userRepository,
                          ITimeSlotRepository timeSlotRepository,
                          IStoreRepository storeRepository,
                          IServiceRepository serviceRepository,
                          IStoreReportRepository storeReportRepository)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _timeSlotRepository = timeSlotRepository;
            _storeRepository = storeRepository;
            _serviceRepository = serviceRepository;
            _storeReportRepository = storeReportRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IOrderRepository OrderRepository => _orderRepository;
        public ITimeSlotRepository TimeSlotRepository => _timeSlotRepository;

        public IStoreReportRepository StoreReportRepository => _storeReportRepository;

        public IStoreRepository StoreRepository => _storeRepository;

        public IServiceRepository ServiceRepository => _serviceRepository;

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
