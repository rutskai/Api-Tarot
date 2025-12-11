using System.Text.RegularExpressions;

namespace Validations
{
    class ValidationName
    {
         /**
         * Valida si un nombre es correcto.
         *
         * Reglas de validación:
         *  - No puede ser nulo o vacío.
         *  - Solo puede contener letras (mayúsculas o minúsculas) sin espacios ni números.
         *
         * @param name Nombre a validar.
         * @return true si el nombre es válido según las reglas; false en caso contrario.
         */
         
         public static bool CheckName(string name) => !string.IsNullOrEmpty(name) && Regex.IsMatch(name, @"^[a-zA-Z]+$");
    }
    
}