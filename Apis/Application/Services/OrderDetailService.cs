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

        public async Task<IEnumerable<Package>> GetAllAsync() => await _unitOfWork.PackageRepository.GetAllAsync();

        public async Task<Package?> GetByIdAsync(Guid entityId) => await _unitOfWork.PackageRepository.GetByIdAsync(entityId);

        public async Task<int> GetCountAsync()
        {
           return await _unitOfWork.PackageRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Package>> GetFilterAsync(BaseFilterringModel entity)
        {
            return await _unitOfWork.PackageRepository.GetFilter(entity);
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.PackageRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Package entity)
        {
            _unitOfWork.PackageRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }
    }
}
