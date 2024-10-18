using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Milestone6PDF
{

    class CSVFile
    {
        public class Record
        {
            public string Name { get; set; }
            public int Amount { get; set; }
        }

        static void Main(string[] args)
        {
            string csvPath = "data.csv";
            string pdfPath = "SummaryReport.pdf";

            // Read data from CSV file
            List<Record> records;
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = new List<Record>(csv.GetRecords<Record>());
            }

            // Create a PDF document
            using (PdfWriter writer = new PdfWriter(pdfPath))
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);

                // Add title
                document.Add(new Paragraph("Summary Report")
                    .SetFontSize(20)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBold());

                // Add a new line
                document.Add(new Paragraph("\n"));

                // Create table
                Table table = new Table(2); // 2 columns
                table.AddHeaderCell(new Cell().Add(new Paragraph(("Name")).SetBold().SetBackgroundColor(ColorConstants.YELLOW)));
                table.AddHeaderCell(new Cell().Add(new Paragraph(("Amount")).SetBold().SetBackgroundColor(ColorConstants.YELLOW)));
             

                // Populate table with data
                foreach (var record in records)
                {
                    table.AddCell(record.Name);
                    table.AddCell(record.Amount.ToString());
                }

                // Add table to the document
                document.Add(table);

                // Close the document
                document.Close();
            }

            Console.WriteLine($"PDF generated successfully at {Path.GetFullPath(pdfPath)}");
        }
    }
}
