using System;
using System.IO;

namespace Milestone4
{
    class csvParser
    {
        static void Main2(string[] args)
        {
            string filePath = "csvInputFile.csv"; 
            DisplayMenuData(filePath);
        }

        static void DisplayMenuData(string filePath)
        {
            
                // Read all lines from the CSV file
                string[] lines = File.ReadAllLines(filePath);

                // Skip the header and process each line
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] values = line.Split(',');

                    if (values.Length == 2)
                    {
                        string itemName = values[0].Trim();
                        string price = values[1].Trim();

                        Console.WriteLine($"Item: {itemName}, Price: {price}");
                    }
                }
            
            
        }
    }
}
