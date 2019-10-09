using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace location_preprocessor.Models
{
    public class LocationData
    {
        [JsonPropertyName("Id")]
        public char Id { get; set; }

        [JsonPropertyName("Locations")]
        public List<LocationOutputData> Locations { get; set; }
    }
}