namespace AoC2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            var input = File.ReadAllText("testInput.txt");
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var fish = entries[0].Split(",").Select(i => new LanternFish
            {
                count = Convert.ToInt32(i)
            }).ToList();
            for (var i = 0; i < 80; i++)
            {
                var addCount = 0;
                foreach (var f in fish)
                {
                    f.count--;
                    if (f.count == -1)
                    {
                        f.count = 6;
                        addCount++;
                    }
                }
                for(var j = 0; j < addCount; j++)
                    fish.Add(new LanternFish{count = 8});
            }
            Console.WriteLine("Solution 1 = " + fish.Count);
        }

        static void Part2()
        {
            var input = File.ReadAllText("testInput.txt");
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var fish = entries[0].Split(",").Select(i => new LanternFish
            {
                count = Convert.ToInt32(i)
            }).ToList();
            for (var i = 0; i < 256; i++)
            {
                var addCount = 0;
                foreach (var f in fish)
                {
                    f.count--;
                    if (f.count == -1)
                    {
                        f.count = 6;
                        addCount++;
                    }
                }
                for(var j = 0; j < addCount; j++)
                    fish.Add(new LanternFish{count = 8});
            }
            Console.WriteLine("Solution 2 = " + fish.Count);
        }
    }

    internal class LanternFish
    {
        internal int count;
    }
}