using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        public BuildingService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime; 
        }

        public async Task<bool> AddAsync(Building building)
        {
            await _unitOfWork.BuildingRepository.AddAsync(building);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<Pagination<Building>> GetAllAsync()
        {
            var o = _unitOfWork.CustomerRepository.GetAllAsync().ToString();
            return _mapper.Map<Pagination<Building>>(o);
        }

        public async Task<Building?> GetByIdAsync(Guid entityId) => await _unitOfWork.BuildingRepository.GetByIdAsync(entityId);

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.BuildingRepository.GetCountAsync();
        }

        public Task<Pagination<Building>> GetCustomerListPagi(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<Building>> GetFilterAsync(BuildingFilteringModel entity)
        {
            var o = _unitOfWork.BuildingRepository.GetFilter(entity).ToList();
            return _mapper.Map<Pagination<Building>>(o);   
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.BuildingRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Building entity)
        {
            _unitOfWork.BuildingRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }
    }
}
