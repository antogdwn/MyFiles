namespace WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            string Line = "my name name is Mansi Anto Verma";
                //"They say that dogs are they man's best friend, but this cat was" +
                //             " setting out to sabotage that theory";


            //Console.WriteLine(Line.Length);
            int Linelen = Line.Length;
            int i = 0;
            int j = 0;
            Dictionary<string, int> WordcountDict = new Dictionary<string, int>();
            List<string> Wordlist = new List<string>();

            while (i<Linelen)
            {
                //Console.WriteLine(Line[i]);
                
                if (Line[i] == ' ' || i ==Linelen -1 )
                {
                    //Console.WriteLine(Line[i]);
                    //Console.WriteLine(j);
                    //indexpos=Line.IndexOf(' ', i);
                    int startpos = j;                    
                    int endpos = i+1;
                    int length = endpos- startpos;
                    //string substring =Line.Substring(startpos, length);
                    Wordlist.Add(Line.Substring(startpos, length).Trim());
                    //Console.WriteLine(Line.Substring(startpos, length).Trim());

                    j = i;
                    //Line.Split()
                }

                i++;
            }
             var Wordlist2=Wordlist.Order();
            foreach (string word in Wordlist2)
            {
                if (WordcountDict.ContainsKey(word))
                {
                    WordcountDict[word] = WordcountDict[word]+1 ; //my name name is Mansi Anto

                }
                else
                {
                    WordcountDict[word] = 1;
                }
            }

            var WordcountDict2 =WordcountDict.OrderByDescending(x=>x.Value);
            foreach(var  kvp in WordcountDict2)
            {
                Console.WriteLine($"word {kvp.Key}, Count: {kvp.Value}");
            }
        }
    }
}
