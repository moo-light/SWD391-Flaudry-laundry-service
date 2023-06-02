using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public static class ExpressionUtils
    {

        public static List<Expression<Func<T, bool>>> CreateListOfExpression<T>(params Expression<Func<T, bool>>[] expressions)
        {
            return new List<Expression<Func<T, bool>>>(expressions.AsEnumerable());
        }

        public static bool EmptyOrEquals(this Guid? thisId, Guid? thatId)
        {
            if (thisId == null || thisId == Guid.Empty) return true;
            if (thatId == thisId) return true;
            return false;
        }
        public static bool EmptyOrContainedIn(this string? @this, string? that)
        {
            if (@this == null || @this == string.Empty) return true;
            if (that?.Contains(@this) ?? false) return true;
            return false;
        }
        public static bool IsInDateTime(this DateTime? dateTime, DateTime? fromDate = default, DateTime? toDate = default)
        {
            if (dateTime == null) return false;
            DateTime timeStart = (fromDate ?? DateTime.MinValue);
            DateTime timeEnd = (toDate ?? DateTime.MaxValue);
            return timeStart <= dateTime && dateTime <= timeEnd;
        }
        public static bool IsInEnumNames(this string current, string[]? enumNames, Type? enumType = null)
        {
            // Return false if current is null or empty
            if (string.IsNullOrEmpty(current)) return false;

            // No filter if enumNames is null, then all values are valid
            if (enumNames == null) return true;

            // Check if all values in enumNames are valid enum names
            if (enumType != null)
                if (enumNames.Any(name => !Enum.IsDefined(enumType, name))) return false;

            // Return true if current is in enumNames
            return enumNames.Contains(current);
        }
    }
}
