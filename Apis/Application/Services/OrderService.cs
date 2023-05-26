using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Order>> GetAllAsync() => await _unitOfWork.OrderRepository.GetAllAsync();
        public async Task<Order?> GetByIdAsync(Guid entityId) => await _unitOfWork.OrderRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(Order order)
        {
            await _unitOfWork.OrderRepository.AddAsync(order);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.OrderRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Order entity)
        {
            _unitOfWork.OrderRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }

    }
}
