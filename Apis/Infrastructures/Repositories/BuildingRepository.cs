using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
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
        public BuildingRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {

        }

        public IEnumerable<Building> GetFilter(BuildingFilteringModel entity)
        {
            entity ??= new();
            Expression<Func<Building, bool>> nameFilter = x => entity.Search.IsNullOrEmpty() || x.Name.Contains(entity.Search);
            Expression<Func<Building, bool>> addressFilter = x => entity.Search.IsNullOrEmpty() || x.Address.Contains(entity.Search);

            var predicates = ExpressionUtils.CreateListOfExpression(nameFilter);
            var result = predicates.Aggregate(_dbSet.AsEnumerable(), (a, predicate) => a.Where(predicate.Compile()));
            return result;
        }
    }
}
