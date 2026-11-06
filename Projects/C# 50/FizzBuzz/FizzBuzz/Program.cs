namespace FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N;
            Dictionary<int, string> FizzBuzzRule = new Dictionary<int, string>();

            Console.WriteLine("Enter Number");
            N = Convert.ToInt32(Console.ReadLine());//15;

            Console.WriteLine("Enter count of rules");
            int DictCount = Convert.ToInt32(Console.ReadLine());//3;

            while (DictCount > 0)
            {
                Console.WriteLine("Enter Key value pairs comma separated");

                string Keyvalue = Console.ReadLine();
                string[] keyvalues = Keyvalue.Split(",");
                FizzBuzzRule.Add(Convert.ToInt32(keyvalues[0]), keyvalues[1]);
                //FizzBuzzRule.Add(5, "Bar");
                keyvalues = [];
                DictCount--;

            }
            //N = 15;
            //FizzBuzzRule.Add(3, "Foo");
            //FizzBuzzRule.Add(4, "Bar");

            string Values = "";
            int subnum = 1;
            while (subnum <= N)
            {
                foreach (var fbr in FizzBuzzRule)
                {
                    if (subnum % fbr.Key == 0)
                    {

                        Values += fbr.Value.Trim();
                    }
                }
                if (!string.IsNullOrEmpty(Values)) { Console.WriteLine(Values); Values = ""; }

                else
                {
                    Console.WriteLine(subnum);
                }
                subnum++;
            }
        }
    }
}
