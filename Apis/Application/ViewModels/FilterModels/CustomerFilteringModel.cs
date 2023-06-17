using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FilterModels
{
    public class CustomerFilteringModel
    {
        ////1 là 1 object search thôi 
        //public string? Search { get; set; } = "a"
        //2 là tất cả lun
        public string?[]? FullName { get; set; }  //ko check la tim tat ca
        public string?[]? Email { get; set; } 
        public string?[]? PhoneNumber { get; set; }
        public string?[]? Address { get; set; } 

    }
}
