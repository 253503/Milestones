using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

class ConfigUpdater
{
    static void Main3(string[] args)
    {
        string jsonFilePath = @"C:\files\appsettings.json";
        string xmlFilePath = @"C:\files\Config.xml";
        string textFilePath = @"C:\files\config.txt";

        string newConnectionString = "Server=prodserver;Database=mydb;";

        UpdateJsonConfig(jsonFilePath, "Connectionstring", newConnectionString);

        UpdateXmlConfig(xmlFilePath, "connectionstring", newConnectionString);

        UpdateTextConfig(textFilePath, "Connectionstring", newConnectionString);

        Console.WriteLine("Configuration files updated successfully.");
    }

    static void UpdateJsonConfig(string filePath, string key, string newValue)
    {
        var jsonDocument = JsonDocument.Parse(File.ReadAllText(filePath));
        var jsonObject = JsonSerializer.Deserialize<JsonObject>(jsonDocument.RootElement.GetRawText());

        if (jsonObject.TryGetProperty("Database", out var databaseElement))
        {
            if (databaseElement.TryGetProperty(key, out _))
            {
                databaseElement[key] = newValue;
            }
        }

        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(filePath, JsonSerializer.Serialize(jsonObject, options));
    }

    static void UpdateXmlConfig(string filePath, string key, string newValue)
    {
        var xmlDocument = XDocument.Load(filePath);

        var element = xmlDocument.Descendants(key).FirstOrDefault();
        if (element != null)
        {
            element.Value = newValue;
        }

        xmlDocument.Save(filePath);
    }

    static void UpdateTextConfig(string filePath, string key, string newValue)
    {
        var lines = File.ReadAllLines(filePath);
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var line in lines)
            {
                if (line.StartsWith(key))
                {
                    writer.WriteLine($"{key}={newValue}");
                }
                else
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}