using System;
using System.Collections.Generic;
using System.Linq;

namespace DRS
{
    public class Sales
    {
        public int ProductID { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal Amount { get; set; }
    }

    class Program
    {
        static void Main2(string[] args)
        {
            var salesData = new List<Sales>
            {
                new Sales { ProductID = 1, SalesDate = new DateTime(2024, 8, 1), Amount = 300 },
                new Sales { ProductID = 2, SalesDate = new DateTime(2024, 8, 2), Amount = 450 }
            };

            Console.WriteLine("Enter a start date for filtering (yyyy-MM-dd):");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter an end date for filtering (yyyy-MM-dd):");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter a minimum amount for filtering:");
            decimal minAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Sort by Amount (asc/desc):");
            string sortByAmount = Console.ReadLine();

            var filteredAndSortedSales = salesData
                .Where(s => s.SalesDate >= startDate && s.SalesDate <= endDate)
                .Where(s => s.Amount >= minAmount)
                .OrderBy(s => sortByAmount.Equals("asc", StringComparison.OrdinalIgnoreCase) ? s.Amount : 0)
                .ThenByDescending(s => sortByAmount.Equals("desc", StringComparison.OrdinalIgnoreCase) ? s.Amount : 0);

            Console.WriteLine("\nFiltered and Sorted Sales Data:");
            foreach (var sale in filteredAndSortedSales)
            {
                Console.WriteLine($"ProductID: {sale.ProductID}, SalesDate: {sale.SalesDate.ToShortDateString()}, Amount: ${sale.Amount}");
            }
        }
    }
}