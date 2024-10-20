using System.Text.RegularExpressions;

namespace Application.Common.Helpers
{
    public static class PasswordHelper
    {
        public static bool CheckPasswordStrength(string password)
        {
            var passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";

            return Regex.IsMatch(password, passwordPattern);
        }
    }
}
