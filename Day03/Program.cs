namespace AoC2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            //Part2();
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
            var length = entries[0].ToString().Length;
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
                epsilonOutput += zeroCount > oneCount ? "1" : "0";
            }
            var gamma = Convert.ToInt64(gammaOutput, 2);
            var epsilon = Convert.ToInt64(epsilonOutput, 2);
            Console.WriteLine("Solution 1 = " + gamma * epsilon);
        }
    }
    
}