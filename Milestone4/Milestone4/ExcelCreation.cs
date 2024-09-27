using System;
using ClosedXML.Excel;

namespace Milestone4
{
    class ExcelCreation
    {
        static void Main3(string[] args)
        {
            string filePath = "RestaurantsExcelFile.xlsx"; 
            CreateExcelFile(filePath);
            ReadExcelFile(filePath);
        }

        static void CreateExcelFile(string filePath)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Restaurants");

            // Add header
            worksheet.Cell(1, 1).Value = "Name";
            worksheet.Cell(1, 2).Value = "Address";
            worksheet.Cell(1, 3).Value = "Rating";

            // Add sample data
            worksheet.Cell(2, 1).Value = "Pasta House";
            worksheet.Cell(2, 2).Value = "456 Elm St";
            worksheet.Cell(2, 3).Value = 4.2;

            workbook.SaveAs(filePath);
            Console.WriteLine("Excel file created successfully.");
        }

        static void ReadExcelFile(string filePath)
        {
            var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet("Restaurants");

            // Read data starting from the second row
            for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
            {
                string name = worksheet.Cell(row, 1).GetString();
                string address = worksheet.Cell(row, 2).GetString();
                double rating = worksheet.Cell(row, 3).GetDouble();

                Console.WriteLine($"Read Restaurant: {name}, Address: {address}, Rating: {rating}");
            }
        }
    }
}
