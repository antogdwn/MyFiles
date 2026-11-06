using System.Collections.Generic;

namespace Divisibility

{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            int Num = 15;

            Dictionary<int, string> Keyvalues = new Dictionary<int, string>();

            Keyvalues.Add(2, "Even");
            Keyvalues.Add(3, "Three");
            Keyvalues.Add(5, "Five");

            int subnum = 1;
            while (subnum <= Num)
            {
                string kvpres = "";
                foreach (var kvp in Keyvalues)
                {

                    if (subnum % kvp.Key == 0)
                    {
                        kvpres += kvp.Value;
                    }

                }

                if (!string.IsNullOrEmpty(kvpres))
                {
                    Console.WriteLine(kvpres);
                    kvpres = "";
                }
                else
                {
                    Console.WriteLine(subnum);
                }
                subnum++;
            }
        }
    }
}
