using System.Text.Json.Serialization;

namespace location_preprocessor.Models
{
    public class LocationInputData
    {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("Plaatsnaam_7")]
        public string Plaatsnaam { get; set; }

        [JsonPropertyName("PlaatsnaamGemeentenaam_6")]
        public string PlaatsnaamGemeentenaam { get; set; }

        [JsonPropertyName("PlaatsnaamPTTWoonplaatsnaam_5")]
        public string PTTWoonplaatsnaam { get; set; }

        [JsonPropertyName("Gemeentenaam_2")]
        public string Gemeentenaam { get; set; }

        [JsonPropertyName("Provincienaam_4")]
        public string Provincienaam { get; set; }
    }
}