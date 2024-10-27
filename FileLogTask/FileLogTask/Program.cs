using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FileLogTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up dependency injection and logging
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                   // builder.AddConsole(); // Log to console
                    builder.SetMinimumLevel(LogLevel.Information); // Set minimum log level
                })
                .BuildServiceProvider();

            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            // Sample Input
            logger.LogInformation("Application started");
            logger.LogInformation("Performing operation...");

            // Simulate some work
            PerformOperation(logger);

            logger.LogInformation("Application ended");
        }

        static void PerformOperation(ILogger logger)
        {
            // Simulate some operation
            logger.LogInformation("Inside PerformOperation method");
            // Here you could add more logic
        }
    }
}
