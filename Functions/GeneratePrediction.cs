using Models;
using static Validations.GeneralValidation;

namespace Functions
{

       /**
     * Genera una predicción personalizada y aleatoria para un usuario basada en una carta seleccionada
     * y en la lista de cartas disponibles.
     *
     * @param userName El nombre del usuario al que se le hará la predicción.
     * @param cards Lista de cartas disponibles para la predicción.
     * @param selectedCard La carta seleccionada por el usuario para generar la predicción.
     * @return Una cadena con la predicción completa o un mensaje de error si los datos no son válidos.
     */

    class GeneratePrediction
    {
        public static Random random = new Random();
        public static string GetPrediction(string userName, List<Models.Card> cards, Card selectedCard)
        {
            if (!IsValid(cards) || !IsValid(selectedCard))
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
