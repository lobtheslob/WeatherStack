using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenWeather.Client.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherStack.Service
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // create a new ServiceCollection 
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            //// create a new ServiceProvider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            try
            {
                await serviceProvider.GetService<IIntegrationService>().Run();
            }
            catch (Exception generalException)
            {
                // log the exception
                var logger = serviceProvider.GetService<ILogger<Program>>();
                logger.LogError(generalException, 
                    "An exception happened while running the integration service.");
            }
            
            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            // add loggers           
            serviceCollection.AddSingleton(loggerFactory);

            //activate logging
            serviceCollection.AddLogging();

            //add client for factory 
            serviceCollection.AddHttpClient();
//             serviceCollection.AddScoped<IIntegrationService, CRUDService>();
            
            // call dependancy injected service
             serviceCollection.AddScoped<IIntegrationService, HttpClientFactoryInstanceManagementService>();

            // For the dealing with errors and faults demos
            // serviceCollection.AddScoped<IIntegrationService, DealingWithErrorsAndFaultsService>();

        }
    }

    }
}
