using System.Runtime.CompilerServices;
using static Delegate_practice.Delegate_practice;
//using static Delegate_practice.Delegate_practice;

namespace Delegate_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Enter Num 1 :");
            //int num1 =Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter Num 2 :");
            //int num2 = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Enter Operation ('+','-','*') :");
            //string Operation =Console.ReadLine();


            ////Console.WriteLine("Hello, World!");
            //CalcDelegate Adddel = Addnum;
            /////Adddel += Subnum;
            ////Adddel(10,5);
            //Console.WriteLine(Adddel(10, 5));

            //CalcDelegate subdel = Subnum;
            //Console.WriteLine(subdel(10, 5));

            ////CalcDelegate muldel = multiply;
            ////Console.WriteLine(subdel(10, 5));

            //Console.WriteLine(multiply(10,5));

            //List<CalcDelegate> calcDelegates = new List<CalcDelegate>();
            //calcDelegates.Add(Addnum);
            //calcDelegates.Add(Subnum);
            //calcDelegates.Add((a,b)=>a*b);

            //foreach(var num in calcDelegates)
            //{
            //    Console.WriteLine(num(10,5));
            //}
            //var myobj = new Delegate_practice();
            //List<int> intlist = new List<int> { 1, 2, 3 };
            //Listvaluedelegate Listdel = ListVaues;
            //Listdel(intlist);

            
            //CalcDelegate Adddel = Addnum;
            /////Adddel += Subnum;
            ////Adddel(10,5);
            //Console.WriteLine(Adddel(10, 5));

            var Delprobj = new Delegate_practice();
            Delprobj.OnCalc= Delprobj.Addnum;

            Delprobj.OnCalc(5, 10);

        }

    }

    public class Delegate_practice
    {
        public delegate int CalcDelegate(int a, int b);

        public CalcDelegate OnCalc {  get; set; }
        public delegate void Listvaluedelegate(List<int> list); 
        //public delegate 

        public  int Addnum(int a, int b)
        {
            //Console.WriteLine($"Sum :{a+b}");
            return (a + b);
        }

        public static int Subnum(int a, int b)
        {
            return (a - b);
        }
        public static Func<int, int, int> multiply = (a, b) => a * b;
 


        public static void ListVaues(List<int> List)
        {
            foreach (int i in List)
            {
                Console.WriteLine(i);
            }

        }

        
    }
}

