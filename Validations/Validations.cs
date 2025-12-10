using Models;
using static Validations.ValidationName;


namespace Validations

{
    class GeneralValidation
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


        public static bool IsValid(List<Card> cards)
        {
            if (cards == null || cards.Count == 0)
            {
                return false;
            }


            return true;
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