using Models;
using System.Net.Http.Json;


namespace Functions
{
    class SelectionCard
    {
        private static readonly HttpClient client = new HttpClient();

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
