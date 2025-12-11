using Models;
using static Validations.ValidationName;


namespace Validations

{
    class GeneralValidation
    {
         /**
         * Valida que un nombre ingresado sea correcto.
         *
         * Reglas de validación:
         *  - Elimina espacios al inicio y final.
         *  - Solo permite letras (según CheckName).
         *  - Si el nombre no es válido, solicita al usuario ingresar nuevamente hasta obtener un valor correcto.
         *
         * @param name Nombre ingresado por el usuario.
         * @return El nombre validado.
         */

        public static string IsValid(string name)
        {
            name = name.Trim();

            if (!CheckName(name))
            {
                Console.WriteLine("Error, esrciba un carácter válido:");
                return IsValid(Console.ReadLine() ?? "");
            }

            return name;
        }

        /**
         * Valida que una lista de cartas no sea nula ni esté vacía.
         *
         * @param cards Lista de cartas a validar.
         * @return true si la lista contiene al menos una carta; false si es nula o vacía.
         */


        public static bool IsValid(List<Card> cards)
        {
            if (cards == null || cards.Count == 0)
            {
                return false;
            }


            return true;
        }

         /**
         * Valida que una carta no tenga campos nulos.
         *
         * @param card Carta a validar.
         * @return true si todos los campos esenciales (Nombre, PalabraClave, Arquetipo) son no nulos;
         *         false si alguno es nulo.
         */

        public static bool IsValid(Card card)
        {
            if (card.Nombre == null || card.PalabraClave == null || card.Arquetipo==null)
            {
                Console.WriteLine("Aviso: una o más cartas tienen elementos nulos.");
                return false;
            }


            return true;
        }

    }
}