using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace DataTools
{
    class Loader
    {
        public String[,] loadStarNumberTypes()
        {
            using (var streamReader = new StreamReader(@"../StarSystemGenerator/data/starNumberType.csv"))
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
                        data[i, j] = kvp.Value.ToString();
                        j++;
                    }
                }
                return data;
            }
        }

        public string[,] loadStarStatModifiers()
        {
            using (var streamReader = new StreamReader(@"../StarSystemGenerator/data/starStatModifiers.csv"))
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
                        data[i, j] = kvp.Value.ToString();
                        j++;
                    }
                }
                return data;
            }

        }
    }
}