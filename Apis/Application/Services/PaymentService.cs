using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        public readonly IUnitOfWork _unitOfWork;
        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Payment entity)
        {
            await _unitOfWork.PaymentRepository.AddAsync(entity);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync() => await _unitOfWork.PaymentRepository.GetAllAsync();

        public async Task<Payment?> GetByIdAsync(Guid entityId) => await _unitOfWork.PaymentRepository.GetByIdAsync(entityId);

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.PaymentRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Payment>> GetFilter(Payment entity)
        {
            return await _unitOfWork.PaymentRepository.GetFilterAsync(entity);

        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.PaymentRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Payment entity)
        {
            _unitOfWork.PaymentRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }
    }
}
