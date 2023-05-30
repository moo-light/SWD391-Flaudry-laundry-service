using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Infrastructures.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }

        public Task<bool> CheckEmailExisted(string email) => _dbContext.Users.AnyAsync(u => u.Email == email);

        public override async Task<IEnumerable<User>> GetFilterAsync(User user)
        {
            IQueryable<User> result = null;

            Expression<Func<User, bool>> address = x => user.Address.IsNullOrEmpty() || x.Address.Contains(user.Address);
            Expression<Func<User, bool>> email = x => user.Email.IsNullOrEmpty() || x.Email.Contains(user.Email);
            Expression<Func<User, bool>> phoneNumber = x => user.PhoneNumber.IsNullOrEmpty() || x.PhoneNumber.Contains(user.PhoneNumber);
            Expression<Func<User, bool>> fullName = x => user.FullName.IsNullOrEmpty() || x.FullName.Contains(user.FullName) ;

            var predicates = ExpressionUtils.CreateListOfExpression(address,email, phoneNumber, fullName);

            result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));
                 
            return result.AsEnumerable();
        }

        public async Task<User> GetUserByUserNameAndPasswordHash(string email, string passwordHash)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync( record => record.Email == email
                                        && record.PasswordHash == passwordHash);
            if(user is null)
            {
                throw new Exception("UserName & password is not correct");
            }


            return user;
        }
    }
}
