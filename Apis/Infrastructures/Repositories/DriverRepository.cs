using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        private readonly AppDbContext _appDbContext;
        public DriverRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _appDbContext = context;
        }

        public  IEnumerable<Driver> GetFilter(UserFilteringModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
