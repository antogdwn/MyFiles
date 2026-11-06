using System.Linq;
using static LeetCode_Easy.Program;

namespace LeetCode_Easy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //int[] nums = { 13, 25, 83, 77 };
            //LeetcodeEasy.SeparateDigits(nums);

            //int[] nums = { 2, 7, 11, 15 };
            //int target = 9;

            //LeetcodeEasy.TwoSum(nums, target);
            //int num = 121;
            //LeetcodeEasy.IsPalindrome(num);
            string Roman = "MCMXCIV";
            //LeetcodeEasy.RomanToInt(Roman);

            string[] words = { "cir", "car" };
            //LeetcodeEasy.LongestCommonPrefix(words);


            //ListNode list1 = new ListNode(1,
            //                    new ListNode(2));//,
            //                       // new ListNode(4)));

            //ListNode list2 = new ListNode(1,
            //                    new ListNode(3,
            //                        new ListNode(4)));

            //LeetcodeEasy.MergeTwoLists(list1, list2);
            //string s =  //"(){}}{";//"()";//"((";//"(]";//"([])";// "()[]{}";//"()"; // , 


            //LeetcodeEasy.IsValid(s);

            LeetcodeEasy.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static class LeetcodeEasy
        {
            //nums =[13, 25, 83, 77 ]  result =[1,3,2,5,8,3,7,7]
            public static int[] SeparateDigits(int[] nums)
            {
                int[] numarr = nums.SelectMany(num => num.ToString()
                                    .Select(c => (int)char.GetNumericValue(c)))
                                    .ToArray();


                //string work = string.Empty;//nums.Select(x => x.ToString());

                //foreach (var item in nums)
                //{

                //    work = string.Concat(work, item);

                //}
                //int[] numarr=work.Select(i => (int)char.GetNumericValue(i)).ToArray();


                return numarr;
            }

            public static int[] TwoSum(int[] nums, int target)
            {

                List<int> intresult = new List<int>();
                //[2,7,11,15], target =  9


                for (int i = 0; i < nums.Length; i++)
                {

                    for (int j = i + 1; j < nums.Length; j++) //j=1,j=2,j=3
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            intresult.Add(i);
                            intresult.Add(j);
                        }

                    }

                }
                return intresult.ToArray();
            }
            public static bool IsPalindrome(int x)
            {
                //num =121
                bool result = false;

                if (x.ToString().Contains('-'))
                {
                    result = false;
                    return result;
                }
                int num = x;
                int temp = 0;
                while (x > 0)
                {

                    temp *= 10;
                    temp += x % 10;

                    x /= 10;
                }

                result = num == temp;

                return result;
            }

            public static int RomanToInt(string s)
            {
                // III  ;  LVIII  ; MCMXCIV 
                //I can be placed before V(5) and X(10) to make 4 and 9.
                //X can be placed before L(50) and C(100) to make 40 and 90.
                //C can be placed before D(500) and M(1000) to make 400 and 900.


                Dictionary<Char, int> RomIntDict = new Dictionary<char, int>();

                RomIntDict.Add('I', 1);
                RomIntDict.Add('V', 5);
                RomIntDict.Add('X', 10);
                RomIntDict.Add('L', 50);
                RomIntDict.Add('C', 100);
                RomIntDict.Add('D', 500);
                RomIntDict.Add('M', 1000);

                int len = s.Length - 1;
                int val1 = 0;
                // M CM XC IV
                //vi
                //IV len=1
                for (int i = len; i >= 0; i--)
                {
                    //MCMXCIV  -- itr1 : i=6 , i-2 , val=4 - IV; itr2: i=4 ,i-2 , val = 94 -xc  ;  itr3 i=2, 
                    // if(s[i] ==)
                    switch (s[i])
                    {
                        case 'I':
                            val1 += RomIntDict[s[i]];
                            break;
                        case 'V':

                            RomIntDict.TryGetValue('I', out int Ivalue);
                            if (i - 1 >= 0 && RomIntDict[s[i - 1]] == Ivalue)
                            {
                                val1 += RomIntDict[s[i]] - 1;
                                i--;
                            }
                            else
                            {
                                val1 += RomIntDict[s[i]];
                            }
                            break;

                        case 'X':

                            RomIntDict.TryGetValue('I', out int Xvalue);
                            if (i - 1 >= 0 && RomIntDict[s[i - 1]] == Xvalue)
                            {
                                val1 += RomIntDict[s[i]] - 1;
                                i--;
                            }
                            else
                            {
                                val1 += RomIntDict[s[i]];
                            }
                            break;

                        case 'L':

                            RomIntDict.TryGetValue('X', out int Lvalue);
                            if (i - 1 >= 0 && RomIntDict[s[i - 1]] == Lvalue)
                            {
                                val1 += RomIntDict[s[i]] - 10;
                                i--;
                            }
                            else
                            {
                                val1 += RomIntDict[s[i]];
                            }
                            break;
                        case 'C':

                            RomIntDict.TryGetValue('X', out int Cvalue);
                            if (i - 1 >= 0 && RomIntDict[s[i - 1]] == Cvalue)
                            {
                                val1 += RomIntDict[s[i]] - 10;
                                i--;
                            }
                            else
                            {
                                val1 += RomIntDict[s[i]];
                            }
                            break;

                        case 'D':

                            RomIntDict.TryGetValue('C', out int Dvalue);
                            if (i - 1 >= 0 && RomIntDict[s[i - 1]] == Dvalue)
                            {
                                val1 += RomIntDict[s[i]] - 100;
                                i--;
                            }
                            else
                            {
                                val1 += RomIntDict[s[i]];
                            }
                            break;
                        case 'M':

                            RomIntDict.TryGetValue('C', out int Mvalue);
                            if (i - 1 >= 0 && RomIntDict[s[i - 1]] == Mvalue)
                            {
                                val1 += RomIntDict[s[i]] - 100;
                                i--;
                            }
                            else
                            {
                                val1 += RomIntDict[s[i]];
                            }
                            break;

                        default: break;
                    }

                }
                return val1;
            }

            public static string LongestCommonPrefix(string[] strs)
            {
                /* 1.for every string in the array , compare it with the subsequent strings,
                 *for every comparison , keep track of the prefix in a array
                 *at the end after all the strings are compared , 
                 *get the longest prefix value from the list
                 */
                //{ "flower", "flow", "flight" }; ==> len =3

                //string str1 = "flower";
                //string str2 = "flow";

                //var minlen=Math.Min(str1.Length,str2.Length);
                //var minlen = strs.Min(s => s.Length);

                //"cir","car"
                List<string> ResultList = new List<string>();
                int strslen = strs.Length;
                if (strslen == 1)
                {
                    return (strs[0]);
                }
                for (int i = 0; i <= strslen - 1; i++)
                {

                    for (int j = i + 1; j <= strslen - 1; j++)
                    {

                        var minlen = Math.Min(strs[i].Length, strs[j].Length);
                        string str1 = strs[i]; string str2 = strs[j];
                        string res = "";

                        for (int k = 0; k < minlen; k++)
                        {
                            if (str1[k] == str2[k])
                            {
                                res = string.Concat(res, str1[k]);
                            }
                            else
                            {
                                break;
                            }

                        }
                        ResultList.Add(res);
                    }
                }
                string LongestPrefix = ResultList.Min(str => str);

                //string LongestPrefix = ResultList.Max(str=>str.SelectMany(str.StartsWith(str));
                //string LongestPrefix = ResultList.Max(str => str.StartsWith(str));
                //finding largest common string value from a list
                /*for
                 
                 */

                return LongestPrefix;
            }
            public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                //    ListNode list1 = new ListNode(1,
                //                    new ListNode(2,
                //                        new ListNode(4)));

                //    ListNode list2 = new ListNode(1,
                //                        new ListNode(3,
                //                            new ListNode(4)));

                // ListNode current = list1;

                //while (current != null)             
                //    Console.WriteLine(current.val);
                //    current = current.next;

                //    public class ListNode
                //    public int val;
                //    public ListNode next;
                //    public ListNode(int val = 0, ListNode next = null)

                //        this.val = val;
                //        this.next = next;
                List<int> IntList1Node = new List<int>();
                List<int> IntList2Node = new List<int>();
                List<int> IntResNode = new List<int>();

                while (list1 != null)
                {
                    //list1 = [1,2], list2 = [1,3,4] //it1 [1,1] it2 [1,1,2,3] --- it3 [1,1,2,3,null,4] it3 wont happen s list1 = null here 

                    IntList1Node.Add(list1.val);
                    list1 = list1.next;

                }

                while (list2 != null)
                {
                    //list1 = [1,2], list2 = [1,3,4] //it1 [1,1] it2 [1,1,2,3] --- it3 [1,1,2,3,null,4] it3 wont happen s list1 = null here 

                    IntList2Node.Add(list2.val);
                    list2 = list2.next;

                }
                var maxlen = IntList1Node.Count >= IntList2Node.Count ? IntList1Node.Count : IntList2Node.Count; //max len 3  list1=2,list2=3
                //0,1,2,count-1 => list1= 1,list2= 2
                for (int i = 0; i < maxlen; i++)
                {
                    if (i <= IntList1Node.Count - 1)
                    {
                        IntResNode.Add(IntList1Node[i]);
                    }
                    if (i <= IntList2Node.Count - 1)
                    {
                        IntResNode.Add(IntList2Node[i]);
                    }
                }

                IntResNode.Sort();
                ListNode dummy = new ListNode(0);
                ListNode current = dummy;

                foreach (int i in IntResNode)
                {
                    current.next = new ListNode(i);
                    current = current.next;

                }


                return dummy.next;
            }
            public static bool IsValid(string s)
            {
                //string s = "()"; "()[]{}" , "([])"
                Stack<char> Stack = new Stack<char>();
                bool result = true;
                int slen = s.Length;
                if (s.StartsWith(')') || s.StartsWith(']') || s.StartsWith('}') || slen == 1)
                {
                    return false;
                }
                //(){}}{
                for (int i = 0; i < slen; i++)

                {
                    if (i >= 0 && s[i].Equals('(') || char.Equals(s[i], '[') || char.Equals(s[i], '{'))
                    {
                        Stack.Push(s[i]);
                    }
                    else if (i > 0 && char.Equals(s[i], ')') || char.Equals(s[i], '}') || char.Equals(s[i], ']'))
                    {
                        switch (s[i])
                        {
                            case ')':
                                if (Stack.Count > 0 && char.Equals(Stack.Peek(), '('))
                                {
                                    Stack.Pop();
                                }
                                else
                                {
                                    result = false;
                                    return result;
                                    //                               
                                }
                                break;
                            case '}':
                                if (Stack.Count > 0 && char.Equals(Stack.Peek(), '{'))
                                {
                                    Stack.Pop();
                                }
                                else
                                {
                                    result = false;
                                    return result;
                                }
                                break;
                            case ']':
                                if (Stack.Count > 0 && char.Equals(Stack.Peek(), '['))
                                {
                                    Stack.Pop();
                                }
                                else
                                {
                                    result = false;
                                    return result;
                                }
                                break;
                            default:
                                break;
                        }
                    }

                }
                if (Stack.Count > 0 && (char.Equals(Stack.Peek(), '(') || char.Equals(Stack.Peek(), '{') || char.Equals(Stack.Peek(), '[')))
                {

                    return false;

                }

                return result;

            }

            public static int RemoveDuplicates(int[] nums)
            {
                //{ 1, 1, 2}
                //{ 0,0,1,1,1,2,2,3,3,4 }  i=0,1,2 ;numslen = 3

                //update the nums array only

                int writeindex = 1;
                for (int i = 1; i < nums.Length; i++)
                {

                    if (nums[i] != nums[i - 1])
                    {
                        nums[writeindex] = nums[i];
                        writeindex++;
                    }

                }
                return writeindex;


            }


        }
    }
}

