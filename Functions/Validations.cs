using System.Text.RegularExpressions;
using Models;

namespace Functions

{
    class Validations
    {
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

        private static bool CheckName(string name) => !string.IsNullOrEmpty(name) && Regex.IsMatch(name, @"^[a-zA-Z]+$");

        public static bool IsValid(List<Card> cards)
        {
            if (cards == null || cards.Count == 0)
            {
                return false;
            }


            return true;
        }

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