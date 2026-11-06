using System.IO;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
namespace AsyncronousProgramming
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            Console.WriteLine("Hello, World!");

            // var Result = await GetGreetingAsync("Hello, async world!");
            //Console.WriteLine(Result);
            //var obj= new Program();
            //var userTask= obj.GetUserDataAsync();
            //var OrderTask= obj.GetOrderDataAsync();
            //await Task.WhenAll(userTask,OrderTask);
            //// Console.WriteLine(userResult);
            //Func<string, List<int>> myDelFunc = LoadNumbersFromFile;
            ////var Results = await Task.Run(() => LoadNumbersFromFile("C:\\Users\\anto.godwin.n\\Documents\\Projects\\ASP.netFullstack\\TextFile.txt"));
            //var Results = await Task.Run(() => myDelFunc("C:\\Users\\anto.godwin.n\\Documents\\Projects\\ASP.netFullstack\\TextFile.txt"));

            //var res2 = await LoadNumbersAsync("C:\\Users\\anto.godwin.n\\Documents\\Projects\\ASP.netFullstack\\TextFile.txt");
            //Console.WriteLine("Completed");

            //string[] urls = new string[]
            //{
            //    "https://jsonplaceholder.typicode.com/posts/1",
            //    "https://jsonplaceholder.typicode.com/posts/2",
            //    "https://jsonplaceholder.typicode.com/posts/3",
            //    "https://jsonplaceholder.typicode.com/comments/1",
            //    "https://jsonplaceholder.typicode.com/users/1"
            //};

            //var result =await LoadUrls(urls);

            Console.WriteLine("starting multiple tasks...\n"); 
            // Define three tasks 
            Task<int> task1 = Task.Run(() => SimulateWork("Task 1", 2000)); 
            Task<int> task2 = Task.Run(() => SimulateWork("Task 2", 3000));
            Task<int> task3 = Task.Run(() =>SimulateWork("Task 3", 1000));
            // Run all tasks together 
            int [] results = await Task.WhenAll(task1, task2, task3);
            Console.WriteLine("All tasks completed!"); 
            
                Console.WriteLine($"Results :{string.Join(" ", results)}");


            }

        public static async Task<string> GetGreetingAsync(string message)
        {
            Console.WriteLine("Going to waiting state");
            await Task.Delay(1000);
            Console.WriteLine("Completed to waiting state");

            return message;

            //Console.WriteLine($"Greeting: {message}");
        }

        public async Task GetUserDataAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("User Data");
        }

        public async Task GetOrderDataAsync()
        {
            await Task.Delay(3000);
            Console.WriteLine("Order Data");
        }

        public static List<int> LoadNumbersFromFile(string path)
        {
            List<int> numbers = new List<int>();

            foreach (var lines in File.ReadLines(path))
            {
                numbers.Add(int.Parse(lines));
            }
            return numbers;
        }

        public static async Task<List<int>> LoadNumbersAsync(string path)
        {
            return await Task.Run(() => LoadNumbersFromFile(path));
        }


        public static async Task<List<string>> LoadUrls(string[] urls)
        {
            List<string> TaskList = new List<string>();

            var cts = new CancellationTokenSource();

            //foreach(var url in urls)
            //{
            //    var response = client.GetAsync(url).Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        Responses.Add(response.Content.ReadAsStringAsync().Result);
            //    }

            //}

            var request = urls.Select(url => client.GetAsync(url, cts.Token)).ToList();  // selects the result of the http request sent using getasync for each url as a task in a list 

            var allRequestTask = Task.WhenAll(request);  // execute all the tasks to get the response message from the task

            var timeOut = Task.Delay(5000);

            var completed = await Task.WhenAny(allRequestTask, timeOut);

            if (completed == timeOut)
            {
                cts.Cancel();
                throw new TimeoutException("The requests took more than 5 seconds.");
            }

            var responses = await allRequestTask;



            var content = responses.Select(response => response.Content.ReadAsStringAsync()).ToList(); // now get the content out of the response message using readasyrting in a list , because readasstringasync gives task<string>

            //var response =request.Select(responses => responses.Result.Content.ReadAsStringAsync());

            var result = await Task.WhenAll(content); // again same execute the task and get the content out of the task in a string rray result


            return [.. result];
        }





        static int SimulateWork(string taskName, int delay) {
            Console.WriteLine($"{taskName} : started...");
            Task.Delay(delay).Wait();
            // simulate work 
            Console.WriteLine($"{taskName} : finished...");
            return delay;
        }

    }
}
