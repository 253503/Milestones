using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up dependency injection and logging
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    //builder.AddConsole(); // Log to console
                    builder.SetMinimumLevel(LogLevel.Information); // Set minimum log level
                })
                .BuildServiceProvider();

            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            // Log messages
            LogMessages(logger);
        }

        static void LogMessages(ILogger logger)
        {
            logger.LogInformation("Application started");
            logger.LogInformation("Performing operation...");

            // Simulate some operation
            PerformOperation(logger);

            logger.LogInformation("Application ended");
        }

        static void PerformOperation(ILogger logger)
        {
            // Simulate an operation
            logger.LogInformation("Inside PerformOperation method");
            // Here you can add more logic as needed
        }
    }
}
