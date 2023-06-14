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
    public class OrderDetailService : IOrderDetail
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddAsync(OrderDetail package)
        {
            await _unitOfWork.OrderDetailRepository.AddAsync(package);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync() => await _unitOfWork.OrderDetailRepository.GetAllAsync();

        public async Task<OrderDetail?> GetByIdAsync(Guid entityId) => await _unitOfWork.OrderDetailRepository.GetByIdAsync(entityId);

        public async Task<int> GetCountAsync()
        {
           return await _unitOfWork.OrderDetailRepository.GetCountAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetFilterAsync(BaseFilterringModel entity)
        {
            return  _unitOfWork.OrderDetailRepository.GetFilter(entity);
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.OrderDetailRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(OrderDetail entity)
        {
            _unitOfWork.OrderDetailRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }
    }
}
