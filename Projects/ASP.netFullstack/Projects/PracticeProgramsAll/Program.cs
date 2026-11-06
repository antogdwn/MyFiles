using AsyncProgramming;
using Delegate;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace PracticeProgramsAll
{

    public delegate Task MyAsyncDelegate();
    internal class Program
    {

        static async Task Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("Hello, World!");
            AsyncPrograms Asyncobj = new AsyncPrograms();


            //await Task.WhenAll(Asyncobj.GetuserDataAsync(), Asyncobj.GetOrderDataAsync());
            //Console.WriteLine($"All Completed : {sw.ElapsedMilliseconds} ms"); 
            //MyAsyncDelegate del = Asyncobj.DoWork1;
            //del += Asyncobj.DoWork2;

            //Console.WriteLine("Parallel execution using task.whenall");

            //var tasks = del.GetInvocationList()
            //     .Cast<MyAsyncDelegate>()
            //     .Select(d => d());

            //await Task.WhenAll(tasks);

            //MyAsyncDelegate del2 = Asyncobj.DownloadFile1Async;
            //del2 += Asyncobj.DownloadFile2Async;
            //del2 += Asyncobj.DownloadFile3Async;

            //var Tasks =del2.GetInvocationList ()
            //    .Cast<MyAsyncDelegate>()
            //    .Select (d => d());
            //await Task.WhenAll(Tasks);

            //var results = await Task.WhenAll(Asyncobj.GenerateResultAsync(101), Asyncobj.GenerateResultAsync(102),
            //                            Asyncobj.GenerateResultAsync(103), Asyncobj.GenerateResultAsync(104),
            //                            Asyncobj.GenerateResultAsync(105));

            //Console.WriteLine(results.Count());

            //var results2 = await await Task.WhenAny(Asyncobj.GetServer1ResponseAsync(), Asyncobj.GetServer2ResponseAsync(), Asyncobj.GetServer3ResponseAsync());

            //Console.WriteLine(results2.ToString());

            //var CancellationTokenSource =new CancellationTokenSource();
            ////CancellationTokenSource.CancelAfter(3000);
            //try
            //{

            //    Task UploadTask = Asyncobj.UploadFileAsync(CancellationTokenSource.Token);
            //    Console.WriteLine("Press C || c to cancel the task...");

            //    var keyPressTask = Task.Run(() =>
            //    {
            //        var key =Console.ReadKey(); // Wait for any key
            //        if(key.Key == ConsoleKey.C) { 
            //            CancellationTokenSource.Cancel();
            //        }
            //    });

            //    await Task.WhenAny(UploadTask, keyPressTask);
            //    await UploadTask;



            //}

            //catch (OperationCanceledException ex) {
            //    Console.WriteLine($"Operation cancelled {ex.Message}");
            //}
            //finally
            //{
            //    CancellationTokenSource.Dispose();
            //}


            //User user1 = new User();
            //user1.Name = "Anto";
            //user1.Subscribedservices = new List<IServices> { new WeatherService(),new StockService(), new NewsService()};

            //var Tasks =user1.Subscribedservices.Select(x=>x.Service(user1.Name)).ToArray();
            // await  Task.WhenAll(Tasks);
            //sw.Stop();
            //Console.WriteLine($"Elapsed time {sw.Elapsed}");
            //public delegate void NotifyUser(string message);

            //NotificationService notification = new NotificationService();
            //Delegate.User User1 = new Delegate.User { Name = "Anto", Notify = notification.SendEmail };
            //User1.Notify += notification.PushNotification;
            //User1.Notify += notification.SendSms;


            MarketPlace market = new MarketPlace();
            
            market.AddProduct(new Product { Name ="mango bar",Price=10});
            market.AddProduct(new Product { Name = "orange bar", Price = 10 });
            market.AddProduct(new Product { Name = "Apple", Price = 100 });



            market.ChangePrice(new Product { Name = "mango bar", Price = 10 }, 8);


        }

    }
}


