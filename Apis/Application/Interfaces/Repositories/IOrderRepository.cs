using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetFilterAsync();
    }
}
