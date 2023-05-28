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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Role entity)
        {
            await _unitOfWork.RoleRepository.AddAsync(entity);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<IEnumerable<Role>> GetAllAsync() => await _unitOfWork.RoleRepository.GetAllAsync();

        public async Task<Role?> GetByIdAsync(Guid entityId) => await _unitOfWork.RoleRepository.GetByIdAsync(entityId);

        public bool Remove(Guid entityId)
        {
            _unitOfWork.RoleRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Role entity)
        {
            _unitOfWork.RoleRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }
    }
}
