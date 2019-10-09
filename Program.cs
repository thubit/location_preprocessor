using System;
using System.Text.Json;
using Serilog;
using System.Collections.Generic;
using System.Linq;

using location_preprocessor.Models;
using location_preprocessor.Services;
using System.IO;

namespace location_preprocessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            LocationInputDataService locationDataProcessor = new LocationInputDataService();
            LocationOutputService locationOutputService = new LocationOutputService();

            List<LocationInputData> locationsInput = locationDataProcessor.ConvertJsonData();
            List<LocationOutputData> locationsOuput = locationOutputService.ConvertInputData(locationsInput);

            string locationJsonData = JsonSerializer.Serialize<List<LocationOutputData>>(locationsOuput, new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                WriteIndented = true
            });

            using var streamWriter = new StreamWriter(@"./LocationDataFiles/output/locations.json");
            streamWriter.WriteLine(locationJsonData);

            Log.Information(locationJsonData);
        }
    }
}


