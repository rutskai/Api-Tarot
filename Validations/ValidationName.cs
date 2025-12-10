using System.Text.RegularExpressions;

namespace Validations
{
    class ValidationName
    {
         public static bool CheckName(string name) => !string.IsNullOrEmpty(name) && Regex.IsMatch(name, @"^[a-zA-Z]+$");
    }
    
}