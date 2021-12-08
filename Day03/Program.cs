namespace AoC2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
        
        static void Part1()
        {
            string input = File.ReadAllText("input.txt");
            //input = "00100\n" +
            //        "11110\n" +
            //        "10110\n" +
            //        "10111\n" +
            //        "10101\n" +
            //        "01111\n" +
            //        "00111\n" +
            //        "11100\n" +
            //        "10000\n" +
            //        "11001\n" +
            //        "00010\n" +
            //        "01010";
            var entries = input.Split('\n',StringSplitOptions.RemoveEmptyEntries).ToList();
            var length = entries[0].ToString().Length - 1;
            var gammaOutput = "";
            var epsilonOutput = "";
            for(var i = 0; i < length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                foreach(var s in entries)
                {
                    if(s[i] == '0') zeroCount++;
                    else oneCount++;
                }
                gammaOutput += zeroCount > oneCount ? "0" : "1";
                epsilonOutput += zeroCount <= oneCount ? "0" : "1";
            }
            var gamma = Convert.ToInt64(gammaOutput, 2);
            var epsilon = Convert.ToInt64(epsilonOutput, 2);
            Console.WriteLine("Solution 1 = " + gamma * epsilon);
        }

        static void Part2()
        {
            string input = File.ReadAllText("input.txt");
            //input = "00100\n" +
            //        "11110\n" +
            //        "10110\n" +
            //        "10111\n" +
            //        "10101\n" +
            //        "01111\n" +
            //        "00111\n" +
            //        "11100\n" +
            //        "10000\n" +
            //        "11001\n" +
            //        "00010\n" +
            //        "01010";
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var length = entries[0].ToString().Length - 1;

            var o2 = GetO2Level(new List<string>(entries), length);
            var co2 = GetCO2Level(new List<string>(entries), length);
            Console.WriteLine("Solution 2 = " + o2 * co2);
        }

        static long GetO2Level(List<string> entries, int length)
        {
            while (entries.Count > 1)
            {
                for (var i = 0; i < length; i++)
                {
                    int zeroCount = 0;
                    int oneCount = 0;
                    foreach (var s in entries)
                    {
                        if (s[i] == '0') zeroCount++;
                        else oneCount++;
                    }
                    entries.RemoveAll(s => (zeroCount > oneCount) ? s[i] == '1' : s[i] == '0');
                    if (entries.Count == 1) break;
                }
            }
            return Convert.ToInt64(entries[0].ToString().TrimEnd('\r'), 2);
        }

        static long GetCO2Level(List<string> entries, int length)
        {
            while (entries.Count > 1)
            {
                for (var i = 0; i < length; i++)
                {
                    int zeroCount = 0;
                    int oneCount = 0;
                    foreach (var s in entries)
                    {
                        if (s[i] == '0') zeroCount++;
                        else oneCount++;
                    }
                    entries.RemoveAll(s => (zeroCount > oneCount) ? s[i] == '0' : s[i] == '1');
                    if (entries.Count == 1) break;
                }
            }
            return Convert.ToInt64(entries[0].ToString().TrimEnd('\r'), 2);
        }
    }
    
}