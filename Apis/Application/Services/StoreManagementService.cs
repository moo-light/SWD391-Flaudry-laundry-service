using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.ViewModels.FilterModels;
using Application.ViewModels.Stores;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StoreManagementService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly AppConfiguration _configuration;
        public StoreManagementService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, AppConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
        }

        public async Task<bool> AddAsync(StoreRequestDTO store)
        {
            var newDriver = _mapper.Map<Store>(store);
            if (newDriver == null) return false;
            await _unitOfWork.StoreRepository.AddAsync(newDriver);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public Task<Pagination<StoreResponseDTO>> GetAllAsync(int pageIndex, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<StoreResponseDTO?> GetByIdAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<Store>> GetCustomerListPagi(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<StoreResponseDTO>> GetFilterAsync(StoreFilteringModel entity, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, StoreRequestDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
