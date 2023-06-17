using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetFilter(BaseFilterringModel entity);
    }
}