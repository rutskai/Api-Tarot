using static Validations.GeneralValidation;
using static Validations.ValidationOptions;

namespace Functions
{
    class Menu
    {
        public static async Task GetMenu(string? name = null)
        {
             var cards = await GetApi.GetApiTarot();

            if (string.IsNullOrEmpty(name))
            {
            Console.WriteLine("\n=== ♱ Predicción de futuro ♱ ===");
            Console.WriteLine("Cuál es tu nombre?");
            name = IsValid(Console.ReadLine() ?? "");
            Console.WriteLine($"\nEncantado/a {name}!");
            }

            Console.WriteLine($"\nVamos a predecir tu futuro! Presiona enter para iniciar la tirada.");
            Console.ReadLine();

            var selectedCard = await SelectionCard.GetSelectionCardAsync();

            if (!IsValid(selectedCard))
            {
                
                Console.WriteLine("Error al acceder a los datos.");
                return;
            }

            Console.WriteLine($"Carta del día seleccionada: {selectedCard.Nombre}  ");
            Console.WriteLine($"Significado: {selectedCard.Significado}");
            Console.WriteLine($"Tipo: {selectedCard.Arquetipo}");
            Console.WriteLine(  GeneratePrediction.GetPrediction(name, cards, selectedCard));

            Console.WriteLine("Deseas realizar otra tirada? (s/n)");
            string option= IsValidOption(Console.ReadLine() ?? "");

            if (option == "s")
            {
                await GetMenu(name);
            }
            else
            {
                Console.WriteLine("Saliendo...");
            }
        }
    }
}