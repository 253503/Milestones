using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Milestone4
{
    class jsonFile
    {
        static void Main(string[] args)
        {
            string filePath = "jsonInput.json"; // Path to your JSON file
            DisplayReviews(filePath);
        }

        static void DisplayReviews(string filePath)
        {
            try
            {
                // Read the JSON file
                string jsonData = File.ReadAllText(filePath);
                var reviewsData = JsonConvert.DeserializeObject<Reviews>(jsonData);

                // Display each review
                foreach (var review in reviewsData.reviews)
                {
                    Console.WriteLine($"Review for {review.Restaurant}: {review.review}, Rating: {review.Rating}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    public class Reviews 
    {
        public Review[] reviews { get; set; }
    }

    public class Review
    {
        public string Restaurant { get; set; }
        public string review { get; set; }
        public int Rating { get; set; }
    }
}
