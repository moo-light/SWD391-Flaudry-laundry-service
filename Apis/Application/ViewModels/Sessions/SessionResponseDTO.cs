using Application.ViewModels.Batchs;
using Application.ViewModels.Buildings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Sessions
{
    public class SessionResponseDTO : SessionRequestDTO
    {
        public Guid? SessionId { get; set; }
      
    }
}
