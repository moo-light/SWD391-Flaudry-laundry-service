using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels.FilterModels;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class StoreManagementRepository : GenericRepository<StoreManager>, IStoreManagementRepository
    {
        public StoreManagementRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
        public IEnumerable<StoreManager> GetFilter(StoreManagerFilteringModel entity)
        {
            entity ??= new();
            Expression<Func<StoreManager, bool>> email = x => entity.Email.IsNullOrEmpty() || entity.Email.Any(y => x.Email != null && x.Email.Contains(y));
            Expression<Func<StoreManager, bool>> phoneNumber = x => entity.PhoneNumber.IsNullOrEmpty() || entity.PhoneNumber.Any(y => x.PhoneNumber != null && x.PhoneNumber.Contains(y));
            Expression<Func<StoreManager, bool>> fullName = x => entity.FullName.IsNullOrEmpty() || entity.FullName.Any(y => x.FullName != null && x.FullName.Contains(y));
            Expression<Func<StoreManager, bool>> date = x => x.CreationDate.IsInDateTime(entity);

            var predicates = ExpressionUtils.CreateListOfExpression(email, phoneNumber, fullName, date);
            IQueryable<StoreManager> seed = Includes(_dbSet.AsNoTracking(), x => x.Store);

            IEnumerable<StoreManager> result = predicates.Aggregate(seed.AsEnumerable(), (a, b) => a.Where(b.Compile()));

            return result.ToList();
        }
    }
}
