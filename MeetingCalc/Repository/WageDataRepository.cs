using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using MeetingCalc.Model;

namespace MeetingCalc.Repository
{
    public class WageDataRepository
    {
        private string _filename;

        public WageDataRepository(string filename)
        {
            _filename = filename;
        }

        public IEnumerable<WageData> GetData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ","
            };

            var list = new List<WageData>();

            using (var reader = new StreamReader(_filename))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    return csv.GetRecords<WageData>().ToList();
                }
            }
        }
    }
}

