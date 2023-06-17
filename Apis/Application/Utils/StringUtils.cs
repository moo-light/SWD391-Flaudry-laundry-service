using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Application.Utils
{
    public static class StringUtils
    {
        public static string Hash(this string input)
        {
            // todo hash the string
            input = BCrypt.Net.BCrypt.HashPassword(input);
            return input;
        }
        public static bool CheckPassword(this string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }

        public static bool IsValidEnum(this string current, Type @enum)
        {
            var values = Enum.GetNames(@enum);

            foreach (var value in values)
                if (value.Contains(current, StringComparison.OrdinalIgnoreCase)) 
                    return true;

            return false;
        }
    }
}
