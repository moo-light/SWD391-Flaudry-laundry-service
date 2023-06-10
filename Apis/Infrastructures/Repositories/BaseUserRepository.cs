using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
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

        public override IQueryable<BaseUser> GetFilter(BaseFilterringModel entity)
        {
            IQueryable<BaseUser> result = null;

            Expression<Func<BaseUser, bool>> address = x => entity.Search.EmptyOrContainedIn(x.Address);
            Expression<Func<BaseUser, bool>> email = x => entity.Search.EmptyOrContainedIn(x.Email);
            Expression<Func<BaseUser, bool>> phoneNumber = x => entity.Search.EmptyOrContainedIn(x.PhoneNumber);
            Expression<Func<BaseUser, bool>> fullName = x => entity.Search.EmptyOrContainedIn(x.FullName);

            var predicates = ExpressionUtils.CreateListOfExpression(address, email, phoneNumber, fullName);

            result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

            return result;
        }

        public async Task<BaseUser?> GetUserByEmailAndPasswordHash(string email, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.PasswordHash == password.Hash()) 
                ?? throw new Exception("Email or password is not correct");
        }

  
    }
}
