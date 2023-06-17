using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories;
public interface IDriverRepository : IGenericRepository<Driver>
{
    IEnumerable<Driver> GetFilter(UserFilteringModel driver);
}
