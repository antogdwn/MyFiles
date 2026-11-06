namespace Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            
            List<int> Int_List = new List<int>{1, 25, 3,20, 4, 5,6,11};

            var Even_number= Int_List.Where(num=> num %2 ==0);
            Console.WriteLine(string.Join(",",Even_number));

            var Square_num = Int_List.Select(num => num * num);
            Console.WriteLine($"Square num: {string.Join(",", Square_num)}");

            var count=Int_List.Where(num=>num>10).Count();


            Console.WriteLine($"count num > 10: {string.Join(",", count)}");

            



        }
    }
}
