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
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var Pairs = new List<Pair>();
            foreach (var l in lines)
            {
                //var count = 0;
                //var newL = "";
                //foreach (var c in l)
                //{
                //    if (c == '[') count++;
                //    if (c == ']') count--;
                //    newL += c;
                //}
                foreach (var c in l)
                {
                    if (c == '[')
                    {
                        Pairs.Add(CreatePair(l[1..]));
                    }
                }
            }
        }

        static Pair CreatePair(string line)
        {
            var pair = new Pair();
            foreach (var c in line)
            {
                if (c == ',') continue;
                if (c == '[') pair.left = CreatePair(line[(line.IndexOf('[') + 1)..]);
                else if (c == ']') return pair;
                else if (int.TryParse(c.ToString(), out var num))
                    if(pair.left == null)
                        pair.left = new Pair
                        {
                            value = num
                        };
                    else
                    {
                        pair.right = new Pair
                        {
                            value = num
                        };
                    }
                else if(pair.left == null) pair.left = CreatePair(line[(line.IndexOf(',') + 1)..]);
                else pair.right = CreatePair(line[(line.IndexOf(',') + 1)..]);

                if (pair.left != null && pair.right != null) break;
            }
            return pair;
        }

        static void Part2()
        {

        }
    }

    internal class Pair
    {
        internal int value;
        internal Pair? left;
        internal Pair? right;

    }
}