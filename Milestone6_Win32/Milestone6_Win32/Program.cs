using System;
using System.Diagnostics;

class Program
{
    static void Main1(string[] args)
    {
        // Define the numbers to sum
        int num1 = 5;
        int num2 = 5;

        // Path to the Python executable
        string pythonPath = @"C:\Python\python.exe"; 
        // Path to the script
        string scriptPath = @"sum_script.py"; 

        // Create a new process to invoke the Python script
        ProcessStartInfo start = new ProcessStartInfo
        {
            FileName = pythonPath,
            Arguments = $"\"{scriptPath}\" {num1} {num2}",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        using (Process process = Process.Start(start))
        {
            using (System.IO.StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadLine();
                Console.WriteLine($"The sum is: {result}");
            }
        }
    }
}