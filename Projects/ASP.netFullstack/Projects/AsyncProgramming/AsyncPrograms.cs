namespace AsyncProgramming
{
    public class AsyncPrograms
    {
        public async Task GetuserDataAsync()
        {

            await Task.Delay(2000);
            Console.WriteLine("User Data");

        }
        public async Task GetOrderDataAsync()
        {

            await Task.Delay(3000);
            Console.WriteLine("Order Data");

        }

        public async Task DoWork1()
        {
            Console.WriteLine("Work1 started");
            await Task.Delay(2000);
            Console.WriteLine("Work1 Finished");

        }
        public async Task DoWork2()
        {
            Console.WriteLine("Work2 started");
            await Task.Delay(1000);
            Console.WriteLine("Work2 Finished");

        }

        public async Task DownloadFile1Async()
        {
            Console.WriteLine("File1 started");
            await Task.Delay(3000);
            Console.WriteLine("File1 Finished");
        }

        public async Task DownloadFile2Async()
        {
            Console.WriteLine("File2 started");
            await Task.Delay(2000);
            Console.WriteLine("File2 Finished");
        }

        public async Task DownloadFile3Async()
        {
            Console.WriteLine("File3 started");
            await Task.Delay(1000);
            Console.WriteLine("File3 Finished");
        }

        public async Task<int> GenerateResultAsync(int studentId)
        {
            Console.WriteLine($"Generating result for Student {studentId}\r\n");
            await Task.Delay(1000);
            Console.WriteLine($"Result generated for Student {studentId}\r\n");
            return studentId;

        }

        public async Task<string> GetServer1ResponseAsync()
        {
            Console.WriteLine("Request sent to server 1");
            await Task.Delay(5000);
            Console.WriteLine("Response received from server 1");
            return "Server 1";

        }
        public async Task<string> GetServer2ResponseAsync()
        {
            Console.WriteLine("Request sent to server 2");
            await Task.Delay(1000);
            Console.WriteLine("Response received from server 2");
            return "Server 2";

        }
        public async Task<string> GetServer3ResponseAsync()
        {
            Console.WriteLine("Request sent to server 3");
            await Task.Delay(2000);
            Console.WriteLine("Response received from server 3");
            return "Server 3";

        }

        public async Task UploadFileAsync(CancellationToken token)
        {
            for (int i = 1; i <= 10; i++)
            {

                token.ThrowIfCancellationRequested();
                await Task.Delay(1000, token);

                Console.WriteLine($"Uploading ...{i * 10}%");

            }
            Console.WriteLine("upload completed");



        }


    }
    public class User
    {
        public string? Name { get; set; }
        public List<IServices>? Subscribedservices { get; set; }

    }

    public interface IServices
    {
        public Task Service(string user);
    }
    public class WeatherService : IServices
    {
        public async Task Service(string user)
        {
            await Task.Delay(3000);
            Console.WriteLine("Weather Sunny 30C");
        }
    }
    public class StockService :IServices
    {
        public async Task Service(string name)
        {
            await Task.Delay(2000);
            Console.WriteLine("Stock price 250 dol");
        }
    }

    public class NewsService :IServices
    {
        public async Task Service(string name)
        {
            await Task.Delay(1000);
            Console.WriteLine("News :News updates here");
        }
    }

}

