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
            var input = File.ReadAllText("input.txt");
            var parts = input[(input.IndexOf(": ", StringComparison.Ordinal) + 2)..].Split(", ");
            var xParts = parts[0][2..].Split("..");
            var yParts = parts[1][2..].Split("..");

            var n = int.Parse(yParts[0]) * -1 - 1;
            var answer = n * (n + 1) / 2;   
            Console.WriteLine("Solution 1 is " + answer);
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var parts = input[(input.IndexOf(": ", StringComparison.Ordinal) + 2)..].Split(", ");
            var xParts = parts[0][2..].Split("..").Select(int.Parse).ToList();
            var yParts = parts[1][2..].Split("..").Select(int.Parse).ToList();
            var count = 0;
            var minXToCheck = 0;
            for (; minXToCheck * (minXToCheck + 1) / 2 < xParts[0]; minXToCheck++)
            {
            }

            for (var x = minXToCheck; x <= xParts[1]; x++)
            {
                for (var y = yParts[0]; y <= -yParts[0]; y++)
                {
                    count += CheckProbe(x, y, xParts, yParts) ? 1 : 0;
                }
            }


            Console.WriteLine("Solution 2 is " + count);
        }

        static bool CheckProbe(int x, int y, List<int> xParts, List<int> yParts)
        {
            var xPos = 0;
            var yPos = 0;
            while (true)
            {
                if (xPos > xParts[1] || yPos < yParts[0]) return false;
                if (xPos >= xParts[0] && yPos >= yParts[0] && xPos <= xParts[1] && yPos <= yParts[1]) return true;
                xPos += x;
                if (x > 0) x--;
                yPos += y;
                y--;
            }
        }
    }
}