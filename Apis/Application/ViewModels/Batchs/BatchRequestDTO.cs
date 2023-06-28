﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Batchs
{
    public class BatchRequestDTO
    {
        public Guid? DriverId { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
    }
}
