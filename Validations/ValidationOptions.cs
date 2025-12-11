using static Validations.ValidationName;

namespace Validations
{
   class ValidationOptions
   {

       /**
         * Valida que la opción ingresada sea correcta.
         *
         * Reglas de validación:
         *  - Elimina espacios al inicio y final, y convierte la entrada a minúsculas.
         *  - La entrada debe ser un nombre válido según CheckName (solo letras).
         *  - Solo se permiten las opciones "s" (sí) o "n" (no).
         *  - Si la entrada no es válida, solicita al usuario que ingrese nuevamente hasta obtener un valor correcto.
         *
         * @param name La opción ingresada por el usuario.
         * @return La opción validada ("s" o "n").
         */
         
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