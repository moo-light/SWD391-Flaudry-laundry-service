using Microsoft.IdentityModel.Tokens;

namespace Application.Utils
{
    public static class StringUtils
    {
        public static string Hash(this string input)
        {
            // todo hash the string
            return input;
        }
        public static bool IsCorrectEnum(this string current, Type @enum)
        {
            var values = Enum.GetNames(@enum);

            foreach (var value in values)
                if (value.Contains(current, StringComparison.OrdinalIgnoreCase)) 
                    return true;

            return false;
        }
    }
}
