using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class BatchRepository : GenericRepository<Batch>, IBatchRepository
    {
        private readonly AppDbContext _appDbContext;
        public BatchRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _appDbContext = context;
        }

        public override Task<IEnumerable<Batch>> GetFilterAsync(Batch entity)
        {
            throw new NotImplementedException();
        }
    }
}
