using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace OutlookTask
{
    class Program
    {
        private static async Task Main1(string[] args)
        {
            string clientId = "0008e470-c01b-441d-81b2-5a69aaf2b8c7";
            string tenantId = "3e1c602f-7880-45e7-b38e-b87855ef174d"; 
            string clientSecret = ">LeR8Q~m0rrUDir4LXei58~7l9b9eqhboDKC4cdkM"; 
            // Initialize the Graph client
            var graphClient = GetGraphClient(clientId, tenantId, clientSecret);

            // Retrieve calendar events
            await GetCalendarEvents(graphClient);
        }

        private static GraphServiceClient GetGraphClient(string clientId, string tenantId, string clientSecret)
        {
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
                .Build();

            var authProvider = new ClientSecretCredential(tenantId, clientId, clientSecret);
            return new GraphServiceClient(authProvider);
        }

        private static async Task GetCalendarEvents(GraphServiceClient graphClient)
        {
            try
            {
                // Define the date range (e.g., next 30 days)
                var events = await graphClient.Me.Events
                    .Request()
                    .Filter("start/dateTime ge '" + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ") + "'")
                    .OrderBy("start/dateTime")
                    .GetAsync();

                // Display events
                Console.WriteLine("Upcoming calendar events:");
                foreach (var calendarEvent in events)
                {
                    Console.WriteLine($"- {calendarEvent.Subject} at {calendarEvent.Start.DateTime}");
                }
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error retrieving calendar events: {ex.Message}");
            }
        }
    }
}
