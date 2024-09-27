using System;
using System.Xml.Linq;

namespace Milestone4
{
    class Program
    {
        static void Main1(string[] args)
        {
            string filePath = "Inputfile.xml";
            DisplayRestaurantData(filePath);
        }
        static void DisplayRestaurantData(string filePath)
        {
           
                // Load the XML file
                XElement restaurants = XElement.Load(filePath);

                // Parse and display the restaurant data
                foreach (XElement restaurant in restaurants.Elements("restaurant"))
                {
                    string name = restaurant.Element("name")?.Value;
                    string address = restaurant.Element("address")?.Value;
                    string rating = restaurant.Element("rating")?.Value;

                    Console.WriteLine($"Restaurant: {name}, Address: {address}, Rating: {rating}");
                }
        }
   
            
    }
}
