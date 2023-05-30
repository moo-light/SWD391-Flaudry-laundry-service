using Domain.Entities;
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

        public static List<Expression<Func<T, bool>>> CreateListOfExpression<T>( params Expression<Func<T, bool>>[] expressions)
        {
            return new List<Expression<Func<T, bool>>>(expressions.AsEnumerable());
        }

        public static bool EmptyOrEquals(this Guid? thisId,Guid? thatId)
        {
            if (thisId == null || thisId == Guid.Empty) return true;
            if (thatId == thisId) return true;
            return false;
        }
        public static bool EmptyOrContainedIn(this string? @this, string? that)
        {
            if (@this == null || @this == string.Empty) return true;
            if (that.Contains(@this)) return true;
            return false;
        }
    }
}
