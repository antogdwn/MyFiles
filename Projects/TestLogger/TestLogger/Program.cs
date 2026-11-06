namespace TestLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ILogger logger = new ConsoleLogger();
            //logger.Log("test");
            OrderService order = new OrderService(logger);
            order.PlaceOrder("1");
        }
           
        

        public class FileLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("Logged to file");
            }
        }

        public class DatabaseLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("Logged to database");
            }
        }

        public class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("Logged to console");
            }
        }

        
    }
}
