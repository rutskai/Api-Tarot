using System.Text.Json;
using static Validations.GeneralValidation;

namespace Functions
{
    class GetApi
    {
         /**
         * Obtiene la lista de cartas del tarot desde la API local.
         * Realiza una petición HTTP GET al endpoint http://localhost:3000/tarot,
         * deserializa la respuesta JSON a una lista de objetos Card y valida los datos.
         * 
         * @return List< Models.Card> Una lista de cartas del tarot. Si ocurre un error en la petición
         *         o la validación falla, retorna una lista vacía.
         */

        public static async Task<List<Models.Card>> GetApiTarot()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://localhost:3000/tarot";

                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                var contentCards = JsonSerializer.Deserialize<List<Models.Card>>(content) ?? new List<Models.Card>();
                
                if (!IsValid(contentCards))
                {
                    Console.WriteLine("Error al acceder a las cartas.");
                    return new List<Models.Card>();
                }

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
