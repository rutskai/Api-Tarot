
using System.Text.Json;

namespace Functions
{

    class GetApi
    {
        public static async Task<List<Models.Card>> GetApiTarot()
        {

            try
            {

                HttpClient client = new HttpClient();

                string url = "http://localhost:3000/tarot";

                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine("\n=== Cartas del tarot ====");

                var contentCards = JsonSerializer.Deserialize<List<Models.Card>>(content) ?? new List<Models.Card>();
                
                if (!Validations.IsValid(contentCards))
                {
                    Console.WriteLine("Error al acceder a las cartas.");
                    return new List<Models.Card>();
                }

                 foreach (var cards in contentCards)
                {
                    Console.WriteLine($"{cards.Nombre} - {cards.Significado}");
                }

                if (contentCards == null)
                    contentCards = new List<Models.Card>();

                return contentCards;

            }
            catch (System.Exception e)
            {

                Console.WriteLine("Error accediendo a la API: " + e);
                return new List<Models.Card>();
            }
        }
    }
}