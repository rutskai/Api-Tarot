
using Models;
namespace Functions
{
    class SelectionCard
    {
        public static Random random = new Random();
        public static Card GetSelectionCard(List<Card> cards)
        {

            if (!Validations.IsValid(cards))
            {
                Console.WriteLine("Aviso: la lista de cartas no es válida o está vacía.");
                return new Card();
            }

            int index = random.Next(cards.Count);
            return cards[index];

        }
    }
}
