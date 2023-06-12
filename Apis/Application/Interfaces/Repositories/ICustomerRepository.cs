using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Task<Customer> GetCustomerByEmailAndPassword(string email, string password);
    }
}
