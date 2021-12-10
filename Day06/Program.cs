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
            });
        }

        static void Part2()
        {

        }
    }

    internal class LanternFish
    {
        internal int count;
    }
}