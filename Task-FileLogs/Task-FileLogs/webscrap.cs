using System;
using System.IO;
using System.Text.RegularExpressions;

class webscrap
{
    static void Main()
    {
        string filePath = "sample.html";

        string htmlContent = File.ReadAllText(filePath);

        string pricePattern = @"<span\s+class\s*=\s*""price"">\$(\d+\.\d{2})<\/span>";

        MatchCollection matches = Regex.Matches(htmlContent, pricePattern);

        Console.WriteLine("Extracted Prices:");
        foreach (Match match in matches)
        {
            if (match.Success)
            {
                Console.WriteLine($"Price: ${match.Groups[1].Value}");
            }
        }
    }
}