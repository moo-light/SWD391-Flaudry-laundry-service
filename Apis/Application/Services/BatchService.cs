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
    public class BatchService : IBatchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BatchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Batch batch)
        {
            await _unitOfWork.BatchRepository.AddAsync(batch);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
        public async Task<IEnumerable<Batch>> GetAllAsync() => await _unitOfWork.BatchRepository.GetAllAsync();

        public async Task<Batch?> GetByIdAsync(Guid entityId) => await _unitOfWork.BatchRepository.GetByIdAsync(entityId);

        public bool Remove(Guid entityId)
        {
           _unitOfWork.BatchRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0; 
        }

        public bool Update(Batch entity)
        {
            _unitOfWork.BatchRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }
    }
}
