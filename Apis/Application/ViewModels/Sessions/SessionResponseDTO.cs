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
        public virtual Batch? Batch { get; set; } = null;
        public virtual Building? Building { get; set; } = null;
    }
}
