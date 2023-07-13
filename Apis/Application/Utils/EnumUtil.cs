using Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils;

public static class EnumUtil
{
    public static bool IsEnum(this string data, Enum @value)
    {
        return data.Equals(nameof(value), StringComparison.OrdinalIgnoreCase);
    }
}
