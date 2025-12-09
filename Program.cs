using System.Diagnostics;
using Functions;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            Process.Start("node", @"./Functions/Tarotapi.js");
            await Task.Delay(2000);
            await Menu.GetMenu();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ocurrió un error en la aplicación: {e}");
        }
    }
}
