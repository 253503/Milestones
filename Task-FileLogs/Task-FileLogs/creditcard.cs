using System.Text.RegularExpressions;

class credircard
{
    static void Main()
    {
        // Path to the input and output log files
        string inputFilePath = "log.txt";
        string outputFilePath = "redacted_log.txt";

        // Read the content of the log file
        string logContent = File.ReadAllText(inputFilePath);

        // Define the regex pattern for credit card numbers
        string creditCardPattern = @"\b\d{4}[- ]\d{4}[- ]\d{4}[- ]\d{4}\b";

        // Redact credit card numbers by replacing them with "REDACTED"
        string redactedContent = Regex.Replace(logContent, creditCardPattern, "REDACTED");

        // Write the redacted content to a new file
        File.WriteAllText(outputFilePath, redactedContent);

        // Notify user of completion
        Console.WriteLine("Sensitive information redacted. Check the output file: " + outputFilePath);
    }
}