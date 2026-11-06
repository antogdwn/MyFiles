using System.Linq;

namespace WordCount2_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            string Sentence = "my name name is Mansi Anto";
            string search = "Mansi";

            Dictionary<string, int> WordcountDict = new Dictionary<string, int>();

            List<string> words = new List<string>();


            var word = Sentence.Split(' ');


            var Result = word
                .Select(x=>x)
                .Where(x => x.Equals(x))
                .GroupBy(x => x)
                .ToDictionary(x=>x.Key,x=>x.Count())
                
                ;
                
                

            Console.WriteLine(string.Join(",", Result));


        }
    }
}
