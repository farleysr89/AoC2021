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
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var y = 0;
            var nodes = new List<Node>();
            foreach (var line in lines)
            {
                var x = 0;
                foreach (var c in line)
                {
                    nodes.Add(new Node
                    {
                        x = x,
                        y = y,
                        value = int.Parse(c.ToString()),
                        distance = y == 0 && x == 0 ? 0 : int.MaxValue
                    });
                    x++;
                }
                y++;
            }

            foreach(var node in nodes)
            {
                foreach (var node1 in nodes.Where(n => !n.processed && 
                                                       (n.x == node.x - 1 && n.y == node.y) ||
                                                   (n.x == node.x + 1 && n.y == node.y) ||
                                                   (n.x == node.x && n.y == node.y - 1) ||
                                                   (n.x == node.x && n.y == node.y + 1)))
                {
                    node1.distance = Math.Min(node1.distance, node1.value + node.distance);
                }

                node.processed = true;

            }

            Console.WriteLine("Solution 1 is = " + nodes.Last().distance);
        }

        static void Part2()
        {

        }
    }

    internal class Node
    {
        internal int x;
        internal int y;
        internal int value;
        internal int distance;
        internal bool processed = false;
    }
}