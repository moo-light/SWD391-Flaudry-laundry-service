using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
