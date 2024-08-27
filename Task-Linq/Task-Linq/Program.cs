using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_Linq
{
    public class Sales
    {
        public int CustomerID { get; set; }
        public decimal PurchaseAmount { get; set; }
    }

    public class SupportTicket
    {
        public int CustomerID { get; set; }
        public int TicketCount { get; set; }
    }

    public class CustomerProfile
    {
        public int CustomerID { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        public int TotalTicketCount { get; set; }
    }

    class Program
    {
        static void Main1(string[] args)
        {
            var salesData = new List<Sales>
            {
                new Sales { CustomerID = 101, PurchaseAmount = 200 },
                new Sales { CustomerID = 102, PurchaseAmount = 150 }
            };

            var supportTicketsData = new List<SupportTicket>
            {
                new SupportTicket { CustomerID = 101, TicketCount = 3 },
                new SupportTicket { CustomerID = 103, TicketCount = 1 }
            };

            var customerProfiles = from sale in salesData
                                   join ticket in supportTicketsData
                                   on sale.CustomerID equals ticket.CustomerID into tickets
                                   from ticket in tickets.DefaultIfEmpty()
                                   group new { sale, ticket } by sale.CustomerID into grouped
                                   select new CustomerProfile
                                   {
                                       CustomerID = grouped.Key,
                                       TotalPurchaseAmount = grouped.Sum(x => x.sale.PurchaseAmount),
                                       TotalTicketCount = grouped.Sum(x => x.ticket?.TicketCount ?? 0)
                                   };

            foreach (var profile in customerProfiles)
            {
                Console.WriteLine($"CustomerID: {profile.CustomerID}");
                Console.WriteLine($"Total Purchase Amount: ${profile.TotalPurchaseAmount}");
                Console.WriteLine($"Total Ticket Count: {profile.TotalTicketCount}");
                Console.WriteLine();
            }
        }
    }
}