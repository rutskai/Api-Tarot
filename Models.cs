using System.Text.Json.Serialization;

namespace Models
{

    /**
     * Representa una carta del tarot.
     * 
     * Cada carta contiene:
     *  - Id: Identificador único de la carta.
     *  - Nombre: Nombre de la carta (por ejemplo, "El Loco").
     *  - Significado: Significado o interpretación de la carta.
     *  - PalabraClave: Palabra clave asociada a la carta (ej. "Aventura").
     *  - Arquetipo: Tipo de arquetipo de la carta (ej. "El Viajero").
     */

    public class Card
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = "";

        [JsonPropertyName("significado")]
        public string Significado { get; set; } = "";

        [JsonPropertyName("palabraClave")]
        public string PalabraClave { get; set; } = "";

        [JsonPropertyName("arquetipo")]
        public string Arquetipo { get; set; } = "";
    }

    /**
     * Representa la respuesta de la API cuando se solicita una carta aleatoria.
     * 
     * Contiene un solo campo:
     *  - CardSelected: La carta seleccionada aleatoriamente desde la API.
     *                  Puede ser null si no se pudo obtener ninguna carta.
     */

    public class RandomCardResponse
    {
        public Card? CardSelected { get; set; }
    }
}
