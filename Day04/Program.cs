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
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();

        }

        static void Part2()
        {
            string input = File.ReadAllText("input.txt");
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }

}