using System;
using System.Globalization;
using System.IO;
using System.Linq;

class LogAnalyzer
{
    
    static bool IsFileInRange(string filePath, DateTime startDate, DateTime endDate)
    {
        // Extract the date from the filename
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string datePart = fileName.Substring(4); 
        if (DateTime.TryParseExact(datePart, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fileDate))
        {
            return fileDate >= startDate && fileDate <= endDate;
        }
        return false;
    }

    static int CountErrorOccurrences(string filePath, string errorMessage)
    {
        int count = 0;

        // Read each line of the file
        foreach (var line in File.ReadLines(filePath))
        {
            // Check if the line contains the specific error message
            if (line.Contains(errorMessage, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        return count;
    }
    static void Main1(string[] args)
    {
       
        const string errorMessage = "Database connection failed";

        
        string logDirectory = @"C:\logs\files"; 

 
        DateTime startDate = DateTime.Today.AddDays(-7);
        DateTime endDate = DateTime.Today;

        
        var logFiles = Directory.GetFiles(logDirectory, "log_*.txt")
                                .Where(file => IsFileInRange(file, startDate, endDate));

        int totalErrorCount = 0;

        foreach (var file in logFiles)
        {
            int fileErrorCount = CountErrorOccurrences(file, errorMessage);
            totalErrorCount += fileErrorCount;
            Console.WriteLine($"File: {Path.GetFileName(file)} - Error Count: {fileErrorCount}");
        }

           Console.WriteLine($"Total occurrences of '{errorMessage}': {totalErrorCount}");
    }

}