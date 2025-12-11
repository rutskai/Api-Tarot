using System.Diagnostics;
using Functions;

class Program
{
/**
 * Punto de entrada de la aplicación de Tarot.
 *
 * Flujo principal:
 *  1. Inicia el servidor Node.js que expone la API de Tarot (Tarotapi.js).
 *  2. Espera 2 segundos para asegurar que el servidor esté listo.
 *  3. Llama al método ResetDeckApi() para reiniciar el mazo de cartas en la API.
 *  4. Inicia el menú principal de la aplicación mediante Menu.GetMenu().
 *
 * Manejo de errores:
 *  - Cualquier excepción durante la ejecución se captura y se muestra en consola.
 */
    static async Task Main(string[] args)
    {
        try
        {
            Process.Start("node", @"./Functions/Tarotapi.js");
            await Task.Delay(2000);
            await ResetDeck.ResetDeckApi();
            await Menu.GetMenu();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ocurrió un error en la aplicación: {e}");
        }
    }
}
