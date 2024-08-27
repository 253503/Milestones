using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace DataCLeanup
{
    // Define the Record class
    public class Record
    {
        public int RecordID { get; set; }
        public DateTime? Date { get; set; }
        public decimal Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Sample raw dataset
            var rawData = new List<Record>
            {
                new Record { RecordID = 1, Date = DateTime.Parse("2024/08/01"), Value = 100 },
                new Record { RecordID = 2, Date = null, Value = 200 },
                new Record { RecordID = 2, Date = DateTime.Parse("2024/08/02"), Value = 200 }
            };

            // Remove duplicates (based on RecordID and Date)
            var distinctRecords = rawData
                .GroupBy(r => new { r.RecordID, r.Date })
                .Select(g => g.First())
                .ToList();

            // Fill missing values: For this example, we’ll fill missing dates with a default date.
            DateTime defaultDate = new DateTime(2000, 1, 1);

            var filledData = distinctRecords
                .Select(r => new Record
                {
                    RecordID = r.RecordID,
                    Date = r.Date ?? defaultDate,
                    Value = r.Value
                })
                .ToList();

            // Display the cleaned data
            Console.WriteLine("Cleaned and Transformed Data:");
            foreach (var record in filledData)
            {
                Console.WriteLine($"RecordID: {record.RecordID}, Date: {record.Date.Value.ToString("yyyy-MM-dd")}, Value: ${record.Value}");
            }
        }
    }
}