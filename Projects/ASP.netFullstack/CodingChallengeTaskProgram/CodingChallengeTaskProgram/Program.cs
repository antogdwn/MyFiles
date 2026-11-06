using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
namespace CodingChallengeTaskProgram
{
    internal class Program
    {
        static async Task Main()
        {

            var weatherService = new WeatherService { Name = "Weather Service " };
            var stockPriceService = new StockPriceService { Name = "Stock Price Service" };
            var newsService = new NewsService { Name = "News Service" };

            // var test = new List<IService> { weatherService, stockPriceService, newsService };
            var User = new User { Name = "Anto", SubscribedServices = new List<IService> { weatherService, stockPriceService, newsService } };

            Stopwatch sw = Stopwatch.StartNew();

            var userResults = User.SubscribedServices
                            .Select(x => x.FetchDataAsync());
                    
            var results =await Task.WhenAll(userResults);
            sw.Stop();
            Console.WriteLine($"Elapsed ms: {sw.ElapsedMilliseconds}");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            //List<Task<string>> subscribed = new List<Task<string>>();

            //foreach (var service in User.SubscribedServices)
            //{
            //    //Console.WriteLine(service.Name);

            //    subscribed.Add(service.FetchDataAsync());



            //}

            //var results = await Task.WhenAll(subscribed);

            //foreach (var result in results)
            //{
            //    Console.WriteLine(result);
            //}

            //public static async Task GetWeathe)rAsync()
            //{

            //}
            //public static async Task GetStockPriceAsync()
            //{

            //}

            //public static async Task GetNewsAsync()
            //{

            //}


        }

        public class User
        {
            public required string Name { get; set; }

            public List<IService>? SubscribedServices { get; set; }
        }

        public class WeatherService : IService
        {
            public required string Name { get; set; }

            public async Task<string> FetchDataAsync()
            {
                Console.WriteLine("getting weather data..");
                await Task.Delay(2000);
                return "Weather :Sunny, 30 C";

            }

        }
        public class StockPriceService : IService
        {
            public required string Name { get; set; }

            public async Task<string> FetchDataAsync()
            {
                Console.WriteLine("getting StockPrice data..");
                await Task.Delay(3000);
                return "Stock price :$250";

            }

        }

        public class NewsService : IService
        {
            public required string Name { get; set; }

            public async Task<string> FetchDataAsync()
            {
                Console.WriteLine("getting News data..");
                await Task.Delay(1000);
                return "News  :Async Programming simplified";

            }

        }

        public interface IService
        {
            public string Name { get; set; }
            public  Task<string> FetchDataAsync();
        }
    }
}
