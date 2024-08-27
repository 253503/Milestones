using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
        string phonePattern = @"^\+?\d{1,4}?[-.\s]?\(?\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$";

        string emailInput = "user@example.com";
        string phoneInput = "+1-555-123-4567";

        bool isEmailValid = ValidateInput(emailInput, emailPattern);
        Console.WriteLine($"Email validation result: {isEmailValid}");

        bool isPhoneValid = ValidateInput(phoneInput, phonePattern);
        Console.WriteLine($"Phone number validation result: {isPhoneValid}");
    }

    static bool ValidateInput(string input, string pattern)
    {
        Regex regex = new Regex(pattern);

        return regex.IsMatch(input);
    }
}