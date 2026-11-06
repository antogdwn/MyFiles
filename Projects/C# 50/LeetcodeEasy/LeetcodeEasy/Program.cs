namespace LeetcodeEasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int [] nums = { 3, 2, 2, 3 };
            int val = 3;
            RemoveElement(nums, val);
        }


        public static int RemoveElement(int[] nums, int val)
        {
            //int [] nums = { 3, 2, 2, 3 }; val=3
            //List<int> myList = nums.ToList();
            //var res = myList.Distinct().Order();

            for (int i=0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    nums[i] = 1000;
                }
            }
            
            return myList.Count;
        }
    }
}
