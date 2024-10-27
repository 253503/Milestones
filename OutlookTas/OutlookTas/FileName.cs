using System;
using System.Net;
using Microsoft.SharePoint.Client;
using Microsoft.Identity.Client;
using Microsoft.Graph.Models;

namespace outlookTask
{
    class FileName
    {
        static void Main(string[] args)
        {
            // Sample Input
            string siteUrl = "https://levelupsolutionsin.sharepoint.com/sites/SampleWebsite";
            string listName = "Tasks";

            // Authentication
            string clientId = "0008e470-c01b-441d-81b2-5a69aaf2b8c7";
            string tenantId = "3e1c602f-7880-45e7-b38e-b87855ef174d";
            string clientSecret = ">LeR8Q~m0rrUDir4LXei58~7l9b9eqhboDKC4cdkM";

            var app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority($"https://login.microsoftonline.com/{tenantId}")
                .Build();

            string[] scopes = new string[] { $"{siteUrl}/.default" };
            AuthenticationResult result = app.AcquireTokenForClient(scopes).ExecuteAsync().Result;

            // Connect to SharePoint Online
            using (ClientContext context = new ClientContext(siteUrl))
            {
                context.ExecutingWebRequest += (s, e) =>
                {
                    e.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + result.AccessToken;
                };

                // Retrieve the list
                List tasksList = context.Web.Lists.GetByTitle(listName);
                CamlQuery query = CamlQuery.CreateAllItemsQuery();
                ListItemCollection items = tasksList.GetItems(query);

                // Load and execute the query
                context.Load(items);
                context.ExecuteQuery();

                // Output the items
                Console.WriteLine("Tasks List:");
                foreach (ListItem listItem in items)
                {
                    Console.WriteLine($"- Task: {listItem["Title"]}");
                }
            }
        }
    }
}
