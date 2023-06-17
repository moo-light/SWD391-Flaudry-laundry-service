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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _appDbContext = context;
        }

        public async Task<Customer> GetCustomerByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<Customer> GetFilter(UserFilteringModel entity)
        {
            entity ??= new();
            Expression<Func<Customer, bool>> address = x => entity.Search.EmptyOrContainedIn(x.Address);
            Expression<Func<Customer, bool>> email = x => entity.Search.EmptyOrContainedIn(x.Email);
            Expression<Func<Customer, bool>> phoneNumber = x => entity.Search.EmptyOrContainedIn(x.PhoneNumber);
            Expression<Func<Customer, bool>> fullName = x => entity.Search.EmptyOrContainedIn(x.FullName);

            var predicates = ExpressionUtils.CreateListOfExpression(address, email, phoneNumber, fullName);

            IEnumerable<Customer> result = predicates.Aggregate(_dbSet.AsEnumerable(), (a, b) => a.Where(b.Compile()));

            return result;
        }

    }
}
