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
            var binary = Convert.ToString(Convert.ToInt32(input, 16), 2);
        }

        static void Part2()
        {

        }
    }
}