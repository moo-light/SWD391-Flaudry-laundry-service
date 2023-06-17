using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class BaseUserRepository : GenericRepository<BaseUser>, IBaseUserRepository
    {
        public BaseUserRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }

        public async Task<bool> CheckEmailExisted(string email)
        {
            return await _dbSet.AnyAsync(x => x.Email == email);
        }

        public IEnumerable<BaseUser> GetFilter(UserFilteringModel? entity)
        {
            entity ??= new();
            //Expression<Func<BaseUser, bool>> address = x => entity.Search.EmptyOrContainedIn(x.);
            Expression<Func<BaseUser, bool>> email = x => entity.Search.EmptyOrContainedIn(x.Email);
            Expression<Func<BaseUser, bool>> phoneNumber = x => entity.Search.EmptyOrContainedIn(x.PhoneNumber);
            Expression<Func<BaseUser, bool>> fullName = x => entity.Search.EmptyOrContainedIn(x.FullName);

            var predicates = ExpressionUtils.CreateListOfExpression( email, phoneNumber, fullName);

            var result = predicates.Aggregate(_dbSet.AsEnumerable(), (a, b) => a.Where(b.Compile()));

            return result.AsQueryable();
        }

        public async Task<BaseUser?> GetUserByEmailAndPasswordHash(string email, string password)
        {
                BaseUser? user = (await GetAllAsync()).FirstOrDefault(x => x.Email == email && password.CheckPassword(x.PasswordHash));
                return user ?? throw new Exception("Email or password is not correct");
        }

  
    }
}
