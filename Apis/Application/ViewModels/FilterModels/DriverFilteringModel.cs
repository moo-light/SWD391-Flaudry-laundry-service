using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FilterModels
{
    public class DriverFilteringModel : BaseFilterringModel
    {
        public string?[]? FullName { get; set; }  //ko check la tim tat ca
        public string?[]? Email { get; set; }
        public string?[]? PhoneNumber { get; set; }
    }
}
