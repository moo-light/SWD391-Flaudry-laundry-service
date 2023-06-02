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
    public class DriverReportService : IDriverReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DriverReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(DriverReport entity)
        {
            await _unitOfWork.DriverReportRepository.AddAsync(entity);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<IEnumerable<DriverReport>> GetAllAsync() => await _unitOfWork.DriverReportRepository.GetAllAsync();

        public async Task<DriverReport?> GetByIdAsync(Guid entityId) => await _unitOfWork.DriverReportRepository.GetByIdAsync(entityId);

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.DriverReportRepository.GetCountAsync();
        }

        public async Task<IEnumerable<DriverReport>> GetFilterAsync(BaseFilterringModel entity)
        {
            return await _unitOfWork.DriverReportRepository.GetFilterAsync(entity);

        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.DriverReportRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public  bool Update(DriverReport entity)
        {
            _unitOfWork.DriverReportRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }
    }
}
