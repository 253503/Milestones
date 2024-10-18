
    using System;
    using System.IO;
    using iText.Kernel.Pdf;
    using iText.Layout;
    using iText.Layout.Element;
    using iText.Layout.Properties;
    using iText.IO.Image;

namespace Milestone6PDF
{
    class Program
    {
        static void Main1(string[] args)
        {
            string title = "Monthly Sales Report";
            string text = "Total Sales: $10,000";
            string imagePath = @"sales_chart.png";
            string pdfPath = "SalesReport.pdf";

            // Create a PDF document
            using (PdfWriter writer = new PdfWriter(pdfPath))
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);

                // Add title
                document.Add(new Paragraph(title)
                    .SetFontSize(22)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBold());

                // Add a new line
                document.Add(new Paragraph("\n"));

                // Add text
                document.Add(new Paragraph(text)
                    .SetFontSize(16)
                    .SetTextAlignment(TextAlignment.LEFT));

                // Add a new line
                document.Add(new Paragraph("\n"));

                // Add image
                if (File.Exists(imagePath))
                {
                    Image image = new Image(ImageDataFactory.Create(imagePath));
                    document.Add(image);
                }
                else
                {
                    Console.WriteLine("Image file not found.");
                }

                // Close the document
                document.Close();
            }

            Console.WriteLine($"PDF generated successfully at {Path.GetFullPath(pdfPath)}");
        }
    }
}