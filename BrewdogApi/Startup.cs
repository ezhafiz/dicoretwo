namespace BrewdogApi
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using HttpService;
    using Brewdog.HtmlGenerator.Services;
    using Brewdog.Extensions.Factory;
   
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to the Brewdog Beer Data retriever");

            Console.WriteLine($"Please enter which page you would like to view");
            var pageNumber = Console.ReadLine();

            if (!int.TryParse(pageNumber, out var pageNumberValue))
            {
                Console.WriteLine($"You must enter a number");
                pageNumber = Console.ReadLine();
            }

            Console.WriteLine($"Please enter how many beers you would like to see");
            var pageSize = Console.ReadLine();

            if (!int.TryParse(pageNumber, out var pageSizeValue))
            {
                Console.WriteLine($"You must enter a number");
                pageSize = Console.ReadLine();
            }

            // resolve the dependency graph
            var appService = InitialiseBrewdogService();

            // Initialise application
            var brewdogApi = new BrewdogApi(appService);

            // run the application
            var beersResponse = brewdogApi.GetBeers(pageNumber, pageSize);
            
            DebugBeers(beersResponse);

            // halt to see data
            Console.ReadLine();
        }

        private static IHttpService InitialiseBrewdogService()
        {
            var services = new ServiceCollection()
                .AddTransient<IHttpService, HttpService>()
                .AddTransient<IHtmlGeneratorService, HtmlGeneratorService>();

            var serviceProvider = services.BuildServiceProvider();

            var appServices = serviceProvider.GetService<IHttpService>();

            return appServices;
        }

        private static void DebugBeers(JToken beersResponse)
        {

            // Build our custom beer object
            var buildBeerObject = BeerFactory.Build(beersResponse);

            //var htmlGenerator = new HtmlGeneratorService(); ;

            //htmlGenerator.GenerateHtml(buildBeerObject);

            foreach (var beer in buildBeerObject)
            {
                Console.WriteLine("");
                Console.WriteLine($"Beer ID: {beer.BeerId}");
                Console.WriteLine($"Beer name: {beer.BeerName}");
                Console.WriteLine($"Beer description: {beer.BeerDescription}");
                Console.WriteLine($"Beer abv: {beer.BeerAbv}");
                Console.WriteLine($"Beer image URL: {beer.BeerImage}");
                Console.WriteLine($"---------------------------------------------------------------------");
            }
            
            //var serializedBeersList = JsonConvert.SerializeObject(buildBeerObject);

            //Console.WriteLine(serializedBeersList);
        }
    }
}
