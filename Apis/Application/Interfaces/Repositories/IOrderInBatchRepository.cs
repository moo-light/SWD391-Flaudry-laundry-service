using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOrderInBatchRepository : IGenericRepository<OrderInBatch>
    {
        IEnumerable<OrderInBatch> GetFilter(BaseFilterringModel entity);
    }
}