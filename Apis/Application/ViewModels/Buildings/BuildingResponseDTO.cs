using Application.ViewModels.LaundryOrders;
using Application.ViewModels.BatchOfBuildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Buildings
{
    public class BuildingResponseDTO : BuildingRequestDTO
    {
        public Guid? BuildingId { get; set; }
        //public ICollection<BatchOfBuildingResponseDTO> BatchOfBuildings { get; set; } = new List<BatchOfBuildingResponseDTO>();
        //public ICollection<LaundryOrderResponseDTO> LaundryOrders { get; set; } = new List<LaundryOrderResponseDTO>();
    }
}
