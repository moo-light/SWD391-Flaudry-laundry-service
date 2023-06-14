using Application.Interfaces;
using Application.Interfaces.Services;
using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderInBatchService : IOrderInBatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderInBatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddAsync(OrderInBatch entity)
        {
            await _unitOfWork.OrderInBatchRepository.AddAsync(entity);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<IEnumerable<OrderInBatch>> GetAllAsync() => await _unitOfWork.OrderInBatchRepository.GetAllAsync();

        public async Task<OrderInBatch?> GetByIdAsync(Guid entityId) => await _unitOfWork.OrderInBatchRepository.GetByIdAsync(entityId);

        public async Task<int> GetCountAsync() => await _unitOfWork.OrderInBatchRepository.GetCountAsync();

        public async Task<IEnumerable<OrderInBatch>> GetFilterAsync(BaseFilterringModel entity)
        {
            return _unitOfWork.OrderInBatchRepository.GetFilter(entity);
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.OrderInBatchRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(OrderInBatch entity)
        {
            _unitOfWork.OrderInBatchRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }
    }
}
