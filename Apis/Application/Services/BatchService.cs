using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BatchService : IBatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;

        public BatchService(IUnitOfWork unitOfWork, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
        }

        public BatchService(IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(Batch batchDTO)
        {
            if (_claimsService.GetCurrentUserId == Guid.Empty) throw new AuthenticationException("User not login");
            var batchId = Guid.NewGuid();
            Guid driverId = _claimsService.GetCurrentUserId;
            var batch = _mapper.Map<Batch>(batchDTO);
            batch.Id = batchId;
            batch.DriverId = driverId;

            await _unitOfWork.BatchRepository.AddAsync(batch);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
        public async Task<IEnumerable<Batch>> GetAllAsync() => await _unitOfWork.BatchRepository.GetAllAsync();

        public async Task<Batch?> GetByIdAsync(Guid entityId) => await _unitOfWork.BatchRepository.GetByIdAsync(entityId);

        public async Task<int> GetCountAsync() => await _unitOfWork.BatchRepository.GetCountAsync();

        public async Task<IEnumerable<Batch>> GetFilterAsync(BaseFilterringModel entity)
        {
            return await _unitOfWork.BatchRepository.GetFilter(entity).ToListAsync();
        }

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
