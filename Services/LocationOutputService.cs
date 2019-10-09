using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using Serilog;
using location_preprocessor.Models;
using System.Text;

namespace location_preprocessor.Services
{
    public class LocationOutputService
    {
        public List<LocationOutputData> ConvertInputData(List<LocationInputData> inputData)
        {
            // Convert input data to output data type
            List<LocationOutputData> output = inputData.Select(location =>
            {
                return new LocationOutputData
                {
                    Id = location.Id,
                    Plaatsnaam = location.Plaatsnaam,
                    Gemeentenaam = location.Gemeentenaam,
                    Provincienaam = location.Provincienaam
                };
            })
            .ToList();

            // Check if plaatsnaam needs to be converted because of strange input data which places Lidwoorden en voorvoegsels infront of the name.
            output.ForEach(loc =>
            {
                if (loc.Plaatsnaam.Contains(','))
                {
                    //Input data will only split into two parts.
                    string[] plaatsnaamParts = loc.Plaatsnaam.Split(',', 2, StringSplitOptions.RemoveEmptyEntries);
                    loc.Alias = loc.Plaatsnaam;
                    loc.Plaatsnaam = plaatsnaamParts[1].Trim() + " " + plaatsnaamParts[0].Trim();
                }
            });

            return output;
        }
    }
}