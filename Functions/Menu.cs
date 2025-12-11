using static Validations.GeneralValidation;
using static Validations.ValidationOptions;

namespace Functions
{
    class Menu
    {

        /**
         * Muestra el menú principal de la aplicación de tarot.
         * Solicita el nombre del usuario, inicia la tirada de cartas
         * y muestra la carta seleccionada junto con su significado y predicción.
         * Permite realizar múltiples tiradas hasta que el usuario decida salir.
         * 
         * @param name (opcional) Nombre del usuario. La primera vez se solicita el nombre por consola, si se decide
         * jugar otra vez, no se vuelve a solicitar el nombre.
         */

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