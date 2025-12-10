using static Validations.ValidationName;

namespace Validations
{
   class ValidationOptions
   {
       public static string IsValidOption(string name)
        {
            name = name.Trim().ToLower();

            if (!CheckName(name))
            {
                Console.WriteLine("Error, no se permiten números, solo se permite 's' o 'n':");
                return IsValidOption(Console.ReadLine() ?? "");
            }

            if (name != "s" && name != "n")
            {
                Console.WriteLine("Error, solo se permite 's' o 'n':");
                return IsValidOption(Console.ReadLine() ?? "");
            }

            return name;
        }

        
   } 
}