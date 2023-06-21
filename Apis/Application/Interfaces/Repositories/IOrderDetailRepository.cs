using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetFilter(OrderDetailFilteringModel entity);
    }
}