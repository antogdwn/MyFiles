
using System.Threading.Tasks;

namespace AsyncDelegateDemo
{
    public delegate Task MyAsyncDelegate();
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MyAsyncDelegate del = DoWork1;
            del += DoWork2;

            Console.WriteLine("\n Seqential Execution-default behaviour");

            await del(); //calls 1 and 2 in order

            Console.WriteLine("Parallel execution- using task.whenall");

            var tasks = del.GetInvocationList()
                .Cast<MyAsyncDelegate>()
                .Select(d => d());

            await Task.WhenAll(tasks);

            Console.WriteLine("Finished");

        }

        private static async Task DoWork2()
        {
            Console.WriteLine("Work2 started..");
            await Task.Delay(1000);
            Console.WriteLine("Work2 finished..");

        }

        private static async Task DoWork1()
        {
            Console.WriteLine("Work1 started..");
            await Task.Delay(2000);
            Console.WriteLine("Work1 finished..");
        }
    }
}
