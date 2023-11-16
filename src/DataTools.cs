using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using System;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using SystemGen;
using System.Diagnostics;
using Newtonsoft.Json;

namespace DataTools
{
    class Loader
    {
        public String[,] loadCsvTable(String tableFile)
        {
            using (var streamReader = new StreamReader($@"../StarSystemGenerator/data/{tableFile}"))
            using (var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            }))
            {
                var records = csvReader.GetRecords<dynamic>().ToList();

                int rowCount = records.Count;
                int columnCount = ((IDictionary<string, object>)records[0]).Count;

                string[,] data = new string[rowCount, columnCount];

                for (int i = 0; i < rowCount; i++)
                {
                    var row = (IDictionary<string, object>)records[i];
                    int j = 0;

                    foreach (var kvp in row)
                    {
                        data[i, j] = kvp.Value?.ToString() ?? string.Empty;
                        j++;
                    }
                }
                return data;
            }
        }
        public void saveSystemJson(List<_System> systems)
        {
            string jsonString = JsonConvert.SerializeObject(systems);
            string filepath = "systems.json";
            File.WriteAllText(filepath, jsonString);
            Debug.WriteLine("Saved Systems to File.");
        }
    }
}