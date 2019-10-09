using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using Serilog;

using location_preprocessor.Models;

namespace location_preprocessor.Services
{
    public class LocationInputDataService
    {
        public List<LocationInputData> ConvertJsonData()
        {
            var locationData = new List<LocationInputData>();
            using var streamReader = File.OpenText(@"LocationDataFiles/input/TypedDataSet.json");
            try
            {
                using var document = JsonDocument.Parse(streamReader.ReadToEnd());

                var root = document.RootElement;
                var locations = root.GetProperty("value");

                //Deserialize the json data to type Location
                foreach (var location in locations.EnumerateArray())
                {
                    String textDate = location.GetRawText();
                    LocationInputData data = JsonSerializer.Deserialize<LocationInputData>(location.GetRawText(), null);
                    locationData.Add(data);
                }

                locationData.ToList().ForEach(l =>
                {
                    l.Plaatsnaam = l.Plaatsnaam.TrimEnd();
                    l.PlaatsnaamGemeentenaam = l.PlaatsnaamGemeentenaam.TrimEnd();
                    l.PTTWoonplaatsnaam = l.PTTWoonplaatsnaam.TrimEnd();
                    l.Gemeentenaam = l.Gemeentenaam.TrimEnd();
                    l.Provincienaam = l.Provincienaam.TrimEnd();
                });
            }
            catch (IOException e)
            {
                Log.Error(e, "Something went wrong... :'(");
            }

            return locationData;
        }
    }
}