using Application.Commons;
using Application.ViewModels.FilterModels;
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
using Application.ViewModels.Batchs;
using Application.ViewModels.Customer;
using Application.ViewModels.Buildings;

namespace Application.Services
{
    public class BatchService : IBatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;

        public BatchService(IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(BatchRequestDTO_V2 batchDTO,Guid? driverId)
        {

            //var newBuilding = _mapper.Map<Building>(building);
            //if (newBuilding == null) return false;
            //await _unitOfWork.BuildingRepository.AddAsync(newBuilding);
            //return await _unitOfWork.SaveChangesAsync() > 0;
            if (_claimsService.GetCurrentUserId == Guid.Empty) throw new AuthenticationException("User not logged in");// you know it's impossible that something can reach this


            // if driverId is inputted from admin then skip this line
            driverId ??= _claimsService.GetCurrentUserId;
            var batch = _mapper.Map<Batch>(batchDTO);

            batch.DriverId = driverId;
            // Add order in batch
            foreach (var orderId in batchDTO.OrderIds)
            {
                batch.OrderInBatches.Add(new OrderInBatch()
                {
                    OrderId = orderId,
                    BatchId = batch.Id
                });
            }
            await _unitOfWork.BatchRepository.AddAsync(batch);// auto generate ID

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<BatchResponseDTO>> GetAllAsync()
        {
            var batch = _unitOfWork.BatchRepository.GetAllAsync(x => x.OrderInBatches, x => x.BatchOfBuildings, x => x.Driver).ToString();
            return _mapper.Map<List<BatchResponseDTO>>(batch);
        }

        public async Task<Batch?> GetByIdAsync(Guid entityId)
        {
            return await _unitOfWork.BatchRepository.GetByIdAsync(entityId, x => x.BatchOfBuildings, x => x.Driver, x => x.OrderInBatches);
        }

        public async Task<int> GetCountAsync() => await _unitOfWork.BatchRepository.GetCountAsync();

        public async Task<Pagination<BatchResponseDTO>> GetBatchListPagi(int pageIndex = 0, int pageSize = 1)
        {
            var batchs = await _unitOfWork.BatchRepository.ToPagination(pageIndex,
                                                                        pageSize,
                                                                        x => x.OrderInBatches,
                                                                        x => x.BatchOfBuildings,
                                                                        x => x.Driver);
            return _mapper.Map<Pagination<BatchResponseDTO>>(batchs);
        }

        public async Task<IEnumerable<Batch>> GetFilterAsync(BatchFilteringModel entity)
        {
            var o = _unitOfWork.BatchRepository.GetFilter(entity).ToList();
            return _mapper.Map<IEnumerable<Batch>>(o);
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.BatchRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }
        public async Task<bool> Update(Guid id, BatchRequestDTO_V2 batchDTO)
        {
            var batch = await _unitOfWork.BatchRepository.GetByIdAsync(id);
            //if (customer.Email != entity.Email)
            //{
            //    if (await _unitOfWork.UserRepository.CheckEmailExisted(entity.Email)) throw new InvalidDataException("Email Exist!");
            //}

            //if (entity.FullName == null) entity.FullName = customer.FullName;
            //if (entity.Email == null) entity.Email = customer.Email;
            //if (entity.Address == null) entity.Address = customer.Address;
            //if (entity.PhoneNumber == null) entity.PhoneNumber = customer.PhoneNumber;

            batch = _mapper.Map(batchDTO, batch);
            // Add order in batch
            foreach (var orderInBatch in batch.OrderInBatches.Where(x=>x.IsDeleted == false))
            {
                _unitOfWork.OrderInBatchRepository.SoftRemove(orderInBatch);
            }

            foreach (var orderId in batchDTO.OrderIds)
            {
                batch.OrderInBatches.Add(new OrderInBatch()
                {
                    OrderId = orderId,
                    BatchId = batch.Id
                });
            }
            _unitOfWork.BatchRepository.Update(batch);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<Pagination<BatchResponseDTO>> GetFilterAsync(BatchFilteringModel batch, int pageIndex, int pageSize)
        {
            var query = _unitOfWork.BatchRepository.GetFilter(batch);
            var batchs = query.Where(c => c.IsDeleted == false).Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var pagination = new Pagination<Batch>()
            {
                TotalItemsCount = query.Where(c => c.IsDeleted == false).Count(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = batchs
            };
            return _mapper.Map<Pagination<BatchResponseDTO>>(pagination);
        }

        public bool SmallUpdate( Batch batch)
        {
            return _unitOfWork.BatchRepository.Update(batch);
        }
    }
}
