namespace NumberProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            List<int> int_list = [1, 2, 3, 4, 5,6];

            var Evennum = int_list.Where(num => num % 2 == 0).OrderBy(num=>num).ToList();
           
            var oddnum = int_list.Where(num => num % 2 != 0).OrderBy(num => num).ToList();

            var squared = int_list.Select(num=>num*num).OrderBy(num=>num).ToList();
            Console.WriteLine(String.Join(",", Evennum));
            Console.WriteLine(String.Join(",", oddnum));
            Console.WriteLine(String.Join(",", squared));

        }
    };
    
}

