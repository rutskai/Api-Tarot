using Models;
using System.Net.Http.Json;


namespace Functions
{
    class SelectionCard
    {
        private static readonly HttpClient client = new HttpClient();

         /**
         * Obtiene una carta aleatoria desde la API del tarot.
         * Realiza una petición GET al endpoint http://localhost:3000/tarot/random
         * y devuelve la carta seleccionada.
         * 
         * @return Card La carta seleccionada aleatoriamente. Si ocurre un error
         *              o la API no devuelve datos válidos, retorna una carta vacía.
         */

        public static async Task<Card> GetSelectionCardAsync()
        {
            try
            {
                RandomCardResponse? response = await client.GetFromJsonAsync<RandomCardResponse>("http://localhost:3000/tarot/random");

                if (response?.CardSelected == null)
                {
                    Console.WriteLine("No se pudo obtener la carta desde el servidor.");
                    return new Card();
                }

                return response.CardSelected;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener carta aleatoria: {ex.Message}");
                return new Card();
            }
        }
    }
   
}
