using System;
using Microsoft.SharePoint.Client;
using System.Security;
using Microsoft.Identity.Client;

namespace ConsoleApp16
{
    class Program
    {
        static void Main1(string[] args)
        {
            string siteUrl = "https://levelupsolutionsin.sharepoint.com/sites/SampleWebsite";
            string libraryName = "Documents";
            string clientId = "0008e470-c01b-441d-81b2-5a69aaf2b8c7"; 
            string clientSecret = "LeR8Q~m0rrUDir4LXei58~7l9b9eqhboDKC4cdkM"; 

            try
            {
                // Authenticate with SharePoint
                var secureClientSecret = new SecureString();
                foreach (char c in clientSecret) secureClientSecret.AppendChar(c);

                using (var context = new ClientContext(siteUrl))
                {
                    context.ExecutingWebRequest += (s, e) =>
                    {
                        e.WebRequestExecutor.RequestHeaders["Authorization"] =
                            "Bearer " + GetAccessToken(siteUrl, clientId, secureClientSecret);
                    };

                    // Load the document library
                    var list = context.Web.Lists.GetByTitle(libraryName);
                    CamlQuery query = CamlQuery.CreateAllItemsQuery();
                    var items = list.GetItems(query);

                    context.Load(items);
                    context.ExecuteQuery();

                    // Output document names
                    Console.WriteLine("Documents in the library:");
                    foreach (var item in items)
                    {
                        if (item.FileSystemObjectType == FileSystemObjectType.File)
                        {
                            Console.WriteLine($"- {item["FileLeafRef"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static string GetAccessToken(string siteUrl, string clientId, SecureString clientSecret)
        {

                var tenantId = "3e1c602f-7880-45e7-b38e-b87855ef174d";
                var authority = $"https://login.microsoftonline.com/{tenantId}";

                var app = ConfidentialClientApplicationBuilder.Create(clientId)
                    .WithClientSecret(new System.Net.NetworkCredential("", clientSecret).Password)
                    .WithAuthority(authority)
                    .Build();

                string[] scopes = new string[] { $"{siteUrl}/.default" };

                var result = app.AcquireTokenForClient(scopes).ExecuteAsync().Result;
                return result.AccessToken;
            

            throw new NotImplementedException("Implement token acquisition.");
        }
    }
}
