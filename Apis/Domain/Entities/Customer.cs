using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer:BaseUser
    {
        public string? Address { get; set; }
        public ICollection<LaundryOrder> Orders { get; set; } = new List<LaundryOrder>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
    