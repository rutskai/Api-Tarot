using System.Text.Json.Serialization;

namespace Models
{
  
public class Card
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } ="";

    [JsonPropertyName("significado")]
    public string Significado { get; set; } ="";

    [JsonPropertyName("palabraClave")]
    public string PalabraClave { get; set; } = "";

    [JsonPropertyName("arquetipo")]
    public string Arquetipo { get; set; } ="";
}
}
