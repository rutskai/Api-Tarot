using Models;

namespace Functions
{
    class GeneratePrediction
    {
        public static Random random = new Random();
        public static string GetPrediction(string userName, List<Models.Card> cards, Card selectedCard)
        {
            if (!Validations.IsValid(cards) || !Validations.IsValid(selectedCard))
            {
                return "\nError al acceder a los datos.";
            }

            string header = $"\nPredicción para {userName}:\n";

            List<string> begginningTemplates = new List<string>
            {
                "Hoy se abre un camino de oportunidades, ",
                "Las estrellas te guían en este día... ",
                "Un nuevo despertar te espera, "
            };

            string beginning = begginningTemplates[random.Next(begginningTemplates.Count)];

            List<string> middleTemplates = new List<string>
            {
              $"la carta {selectedCard.Nombre} indica que, " ,
              $"de acuerdo con lo que indica la carta {selectedCard.Nombre}, ",
                $"la energía de la carta {selectedCard.Nombre}, "
            };

            string middle = middleTemplates[random.Next(middleTemplates.Count)];

            string ending = PhraseSelector.GetRandomPhrase(selectedCard.PalabraClave);

            return header + beginning + middle + ending;




        }
    }
}
