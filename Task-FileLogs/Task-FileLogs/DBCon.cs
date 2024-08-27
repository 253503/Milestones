using System;
using System.Data.SqlClient;
using System.IO;

class DataMigrator
{
    static void Main2(string[] args)
    {
        string filePath = @"C:\customers.txt"; 

        string connectionString = @"Server=your_server_name;Database=your_database_name;User Id=your_user_id;Password=your_password;";

        ProcessFile(filePath, connectionString);
    }

    static void ProcessFile(string filePath, string connectionString)
    {
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var fields = line.Split('|');

            if (fields.Length == 3)
            {
                var firstName = fields[0].Trim();
                var lastName = fields[1].Trim();
                var email = fields[2].Trim();
                var phone = fields[3].Trim();

                InsertRecord(connectionString, firstName, lastName, email, phone);
            }
            else
            {
                Console.WriteLine($"Skipping invalid line: {line}");
            }
        }
    }

    static void InsertRecord(string connectionString, string firstName, string lastName, string email, string phone)
    {
        string query = "INSERT INTO Customers (FirstName, LastName, Email, Phone) VALUES (@FirstName, @LastName, @Email, @Phone)";

        using (var connection = new SqlConnection(connectionString))
        {
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}