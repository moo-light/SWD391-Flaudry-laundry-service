using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ILaundryOrderRepository : IGenericRepository<LaundryOrder>
    {
        IEnumerable<LaundryOrder> GetFilter(BaseFilterringModel entity);
    }
}
