using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<LaundryOrder>
    {
        IEnumerable<LaundryOrder> GetFilter(LaundryOrderFilteringModel entity);
    }
}
