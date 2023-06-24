using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomValidations
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class TimeValidationAttribute : ValidationAttribute
    {
        public TimeValidationAttribute()
        {
        }

        public override bool IsValid(object? value)
        {
            DateTime result;
            bool parsed = DateTime.TryParse((string)value, out result);
            if (!parsed && DateTime.Now < result)
            {
                ErrorMessage = "Date Time input not valid";
                return false;
            }
            return true;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
