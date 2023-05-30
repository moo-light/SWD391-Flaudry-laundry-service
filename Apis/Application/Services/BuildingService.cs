﻿using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;
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