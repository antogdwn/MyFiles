
using System.Security.Cryptography.X509Certificates;

namespace Delegate2
{
    internal class Program
    {
        public delegate void printdel(string x);
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            printdel printd = printmethod;
            printd("Hello");




        }

        public static void printmethod(string x) => Console.WriteLine(x);
    }
}
