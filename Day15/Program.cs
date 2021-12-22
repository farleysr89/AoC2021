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
            var input = File.ReadAllText("input.txt");

            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var y = 0;
            var x = 0;
            var nodes = new Dictionary<(int, int), Node>();
            foreach (var line in lines)
            {
                x = 0;
                foreach (var c in line)
                {
                    nodes.Add((x,y),new Node
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

            var maxX = x * 5;
            var maxY = y * 5;
            var length = x;
            for (var i = 0; i < maxY; i++)
            {
                for (var j = 0; j < maxX; j++)
                {
                    if (nodes.ContainsKey((j, i))) continue;
                    var val = nodes[(j % length, i % length)].value;
                    val += i / length + j / length;
                    val %= 9;
                    if (val == 0) val = 9;
                    nodes.Add((j, i), new Node
                    {
                        x = j,
                        y = i,
                        value = val,
                        distance = int.MaxValue
                    });
                }
            }
            var nodesToProcess = new Queue<(int, int)>();
            nodesToProcess.Enqueue((0,0));
            while(nodesToProcess.Any())
            {
                var (item1, item2) = nodesToProcess.Dequeue();
                var value = nodes[(item1, item2)];

                if (nodes.ContainsKey((item1 - 1, item2)))
                {
                    var node1 = nodes[(item1 - 1, item2)];
                    var distance = Math.Min(node1.distance, node1.value + value.distance);
                    if (distance < node1.distance)
                    {
                        node1.distance = Math.Min(node1.distance, node1.value + value.distance);
                        nodesToProcess.Enqueue((node1.x, node1.y));
                    }
                }
                if (nodes.ContainsKey((item1 + 1, item2)))
                {
                    var node1 = nodes[(item1 + 1, item2)];
                    var distance = Math.Min(node1.distance, node1.value + value.distance);
                    if (distance < node1.distance)
                    {
                        node1.distance = Math.Min(node1.distance, node1.value + value.distance);
                        nodesToProcess.Enqueue((node1.x, node1.y));
                    }
                }
                if (nodes.ContainsKey((item1, item2 - 1)))
                {
                    var node1 = nodes[(item1, item2 - 1)];
                    var distance = Math.Min(node1.distance, node1.value + value.distance);
                    if (distance < node1.distance)
                    {
                        node1.distance = Math.Min(node1.distance, node1.value + value.distance);
                        nodesToProcess.Enqueue((node1.x, node1.y));
                    }
                }
                if (nodes.ContainsKey((item1, item2 + 1)))
                {
                    var node1 = nodes[(item1, item2 + 1)];
                    var distance = Math.Min(node1.distance, node1.value + value.distance);
                    if (distance < node1.distance)
                    {
                        node1.distance = Math.Min(node1.distance, node1.value + value.distance);
                        nodesToProcess.Enqueue((node1.x, node1.y));
                    }
                }

            }

            Console.WriteLine("Solution 2 is = " + nodes[(maxX - 1,maxY - 1)].distance);
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