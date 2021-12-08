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
            List<int> entries = input.Split('\n').Select(int.Parse).ToList();
            int entry = -1;
            int count = 0;
            foreach (var i in entries)
            {
                if(entry != -1 && i > entry)
                {
                    count++;                    
                }
                entry = i;
            }
            Console.WriteLine("solution 1 = " + count);
        }

        static void Part2()
        {
            string input = File.ReadAllText("input.txt");
            List<int> entries = input.Split('\n').Select(int.Parse).ToList();
            var runningSum = 0;
            var nextSum = 0;
            var count = 0;
            var addCount = 0;
            foreach (var i in entries)
            {
                if(addCount < 3)
                {
                    runningSum += i;
                    addCount++;
                    nextSum = runningSum;
                    continue;
                }
                nextSum += i;
                nextSum -= entries[addCount - 3];
                if(nextSum > runningSum)
                    count++;
                nextSum = runningSum;
                addCount++;
                runningSum = nextSum;
            }
            Console.WriteLine("solution 2 = " + count);
        }
    }
}