﻿using Application.ViewModels.LaundryOrders;
using Application.ViewModels.Sessions;
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
        public ICollection<SessionResponseDTO> Sessions { get; set; } = null;
        public ICollection<LaundryOrderResponseDTO> LaundryOrders { get; set; } = null;
    }
}
