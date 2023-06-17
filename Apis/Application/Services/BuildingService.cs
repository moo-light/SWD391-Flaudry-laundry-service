using Application.Interfaces;
using Application.Interfaces.Services;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
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
        public BuildingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Building building)
        {
            await _unitOfWork.BuildingRepository.AddAsync(building);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<IEnumerable<Building>> GetAllAsync() => await _unitOfWork.BuildingRepository.GetAllAsync();

        public async Task<Building?> GetByIdAsync(Guid entityId) => await _unitOfWork.BuildingRepository.GetByIdAsync(entityId);

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.BuildingRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Building>> GetFilterAsync(BuildingFilteringModel entity)
        {
            return  _unitOfWork.BuildingRepository.GetFilter(entity);
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
