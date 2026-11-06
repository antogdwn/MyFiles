using System.Linq;

namespace LeetCode75
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string word1 = "ab c";
            string word2 = "pqr";
            //Solution.MergeAlternately(word1, word2);

            int[] candies = { 2, 3, 5, 1, 3 };
            int extraCandies = 3;
            //Solution.KidsWithCandies(candies, extraCandies);
            int[] flowerbed = { 0, 0, 1, 0, 0 }; //{ 1, 0, 0, 0, 1, 0, 0 };
            int n = 1;
            //bool result = Solution.CanPlaceFlowers(flowerbed, n);
            //Console.WriteLine(result);

            string reverse = "ai";
            Solution.ReverseVowels(reverse);
        }

        public static class Solution
        {
            public static string MergeAlternately(string word1, string word2)
            {

                int word1len = word1.Length; //2 ab
                int word2len = word2.Length; //1 p
                string result = string.Empty;
                int index = word1len > word2len ? word1len : word2len; //2

                for (int i = 0; i < index; i++) //index 2 -- i =0,1
                {
                    if (word1len - 1 >= i) //0   itr 1 -->  1<=0  false
                    {
                        result = string.Concat(result, word1[i].ToString());
                    }

                    if (word2len - 1 >= i)
                    {
                        result = string.Concat(result, word2[i].ToString());
                    }


                }


                return result;
            }
            public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
            {
                int maxcandies = candies.Max(x => x);
                IList<bool> result = new List<bool>();

                foreach (int kid in candies)
                {
                    if (kid + extraCandies >= maxcandies)
                    {
                        result.Add(true);
                    }
                    else
                    {
                        result.Add(false);
                    }
                }

                return result;
            }

            public static bool CanPlaceFlowers(int[] flowerbed, int n)
            {

                //bool result = false;

                int count = 0;
                //[ 0,0,0]  i >=0 & <  flowerbed.length

                for (int i = 0; i < flowerbed.Length; i++)
                {
                    bool nextelement = false, prevelement=false;
                    if (flowerbed[i] == 0)
                    {



                        if (flowerbed.Length == 1)
                        {
                            flowerbed[i] = 1;
                            count++;
                        }

                        if (i + 1 < flowerbed.Length && flowerbed[i + 1] == 0) //next element 
                        {

                            prevelement = true;

                        }

                        if (prevelement && i - 1 >= 0 && flowerbed[i - 1] == 0) //previous element
                        {
                            nextelement = true;
                        }


                    }
                    if ( nextelement == true)
                    {
                        flowerbed[i] = 1;
                        count++;

                    }

                }
                if (count >= n)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static string ReverseVowels(string inputstr)
            {
                //leetcode  leotcede  //vow eeoe
                string vowels ="aeiouAEIOU";
                char[] inputarr =inputstr.ToCharArray();
                var VowelArr = inputstr.Where(x => vowels.Contains(x)).Reverse().ToArray();//eeoe

                int j = 0;
                for( int i = 0; i < inputstr.Length ; i++)
                {
                    if (vowels.Contains(inputstr[i]))
                    {
                        inputarr[i]=VowelArr[j];
                        j++;
                    }
                    
                }

               return string.Join("",inputarr);

            }

        }
    }
}
