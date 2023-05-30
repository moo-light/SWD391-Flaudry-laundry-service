using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
    {
        private readonly AppDbContext _appDbContext;
        public BuildingRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _appDbContext = context;
        }

        public override Task<IEnumerable<Building>> GetFilterAsync(Building entity)
        {
            throw new NotImplementedException();
        }
    }
}
