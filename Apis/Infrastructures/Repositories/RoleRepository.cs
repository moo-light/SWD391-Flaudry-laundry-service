using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _appDbContext;
        public RoleRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _appDbContext = context;
        }


        public override Task<IQueryable<Role>> GetFilterAsync(BaseFilterringModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
