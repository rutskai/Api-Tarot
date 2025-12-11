
namespace Functions
{
    class ResetDeck
    {
        private static HttpClient client = new HttpClient();

        /**
         * Resetea el mazo de cartas del tarot a través de la API.
         * <p>
         * Este método realiza una petición HTTP GET al endpoint /tarot/reset
         * y muestra en consola si la operación fue exitosa o si hubo un error.
         * </p>
         *
         * @async
         * @return Task que representa la operación asincrónica.
         * @throws Exception si ocurre un error al llamar a la API.
         *
         */

        public static async Task ResetDeckApi()
        {
            try
            {
                var response = await client.GetAsync("http://localhost:3000/tarot/reset");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("El mazo ha sido reseteado correctamente.");
                }
                else
                {
                    Console.WriteLine("Error al resetear el mazo.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al llamar a la API de reset: {ex.Message}");
            }
        }

    }

}
