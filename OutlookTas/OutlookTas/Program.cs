using System;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample Input
            string recipient = "Gaythri@ervikashverma.onmicrosoft.com";
            string subject = "Monthly Report";
            string body = "Please find the attached report.";
            string attachmentPath = @"C:\report.pdf";

            // Create Outlook application
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

            try
            {
                // Set email properties
                mailItem.To = recipient;
                mailItem.Subject = subject;
                mailItem.Body = body;

                // Attach the file
                if (!string.IsNullOrEmpty(attachmentPath))
                {
                    mailItem.Attachments.Add(attachmentPath, Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                }

                // Send the email
                mailItem.Send();
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Clean up
                System.Runtime.InteropServices.Marshal.ReleaseComObject(mailItem);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookApp);
            }
        }
    }
}
