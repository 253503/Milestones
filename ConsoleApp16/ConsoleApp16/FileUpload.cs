using System;
using System.IO;
using Microsoft.SharePoint.Client;
using System.Security;
using Microsoft.Identity.Client;
  
    namespace ConsoleApp16
    {
        class FileUpload
        {
            static void Main(string[] args)
            {
            // Sample Input
                string siteUrl = "https://levelupsolutionsin.sharepoint.com/sites/SampleWebsite";
                string libraryName = "Documents";
                string filePath = @"c:\INPUT1.docx"; 
                string clientId = "0008e470-c01b-441d-81b2-5a69aaf2b8c7";
                string clientSecret = "LeR8Q~m0rrUDir4LXei58~7l9b9eqhboDKC4cdkM";

            try
                {
                    // Upload the document
                    UploadFileToSharePoint(siteUrl, libraryName, filePath, clientId, clientSecret);
                    Console.WriteLine("File uploaded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            private static void UploadFileToSharePoint(string siteUrl, string libraryName, string filePath, string clientId, string clientSecret)
            {
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

                    // Read the file and upload it
                    FileCreationInformation newFile = new FileCreationInformation
                    {
                        Content = System.IO.File.ReadAllBytes(filePath),
                        Url = Path.GetFileName(filePath),
                        Overwrite = true
                    };

                    Microsoft.SharePoint.Client.File uploadFile = list.RootFolder.Files.Add(newFile);
                    context.Load(uploadFile);
                    context.ExecuteQuery();
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
            }
        }
    }

