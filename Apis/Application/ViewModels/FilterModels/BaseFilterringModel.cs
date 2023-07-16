using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FilterModels
{
    public class BaseFilterringModel
    {
        [AllowNull]
        public DateTime? FromDate { get; set; } = DateTime.MinValue;
        [AllowNull]
        public DateTime? ToDate { get; set; } = DateTime.MaxValue;
    }
}
