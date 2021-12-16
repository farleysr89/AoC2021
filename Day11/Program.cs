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
            var flashes = 0;
            int y = 0;
            var octopi = new List<Octopus>();
            foreach (var line in lines)
            {
                int x = 0;
                foreach (var c in line)
                {
                    octopi.Add(new Octopus
                    {
                        x = x,
                        y = y,
                        value = int.Parse(c.ToString())
                    });
                    x++;
                }
                y++;
            }

            var maxX = octopi.Max(o => o.x);
            var maxY = octopi.Max(o => o.y);
            for (var i = 0; i < 100; i++)
            {
                foreach (var o in octopi)
                {
                    o.value++;
                    o.flashed = false;
                }

                var flashed = true;
                while (flashed)
                {
                    flashed = false;
                    foreach (var o in octopi)
                    {
                        if (o.value > 9)
                        {
                            o.value = 0;
                            flashes++;
                            o.flashed = true;
                            flashed = true;
                            if(o.x > 0 && o.y > 0)
                                if (octopi.Any(oo => oo.x == o.x - 1 && oo.y == o.y - 1 && oo.flashed == false))
                                {
                                    var oo = octopi.First(oo => oo.x == o.x - 1 && oo.y == o.y - 1 && oo.flashed == false);
                                    oo.value++;
                                }
                            if(o.y > 0)
                                if (octopi.Any(oo => oo.x == o.x && oo.y == o.y - 1 && oo.flashed == false))
                                {
                                    var oo = octopi.First(oo => oo.x == o.x && oo.y == o.y - 1 && oo.flashed == false);
                                    oo.value++;
                                }
                            if(o.x < maxX && o.y > 0)
                                if (octopi.Any(oo => oo.x == o.x + 1 && oo.y == o.y - 1 && oo.flashed == false))
                                {
                                    var oo = octopi.First(oo => oo.x == o.x + 1 && oo.y == o.y - 1 && oo.flashed == false);
                                    oo.value++;
                                }
                            if(o.x > 0)
                                if (octopi.Any(oo => oo.x == o.x - 1 && oo.y == o.y && oo.flashed == false))
                                {
                                    var oo = octopi.First(oo => oo.x == o.x - 1 && oo.y == o.y && oo.flashed == false);
                                    oo.value++;
                                }
                            if(o.x < maxX)
                                if (octopi.Any(oo => oo.x == o.x + 1 && oo.y == o.y && oo.flashed == false))
                                {
                                    var oo = octopi.First(oo => oo.x == o.x + 1 && oo.y == o.y && oo.flashed == false);
                                    oo.value++;
                                }
                            if(o.x > 0 && o.y < maxY)
                                if (octopi.Any(oo => oo.x == o.x - 1 && oo.y == o.y + 1 && oo.flashed == false))
                                {
                                    var oo = octopi.First(oo => oo.x == o.x - 1 && oo.y == o.y + 1 && oo.flashed == false);
                                    oo.value++;
                                }
                            if(o.y < maxY)
                                if (octopi.Any(oo => oo.x == o.x && oo.y == o.y + 1 && oo.flashed == false))
                                {
                                    var oo = octopi.First(oo => oo.x == o.x && oo.y == o.y + 1 && oo.flashed == false);
                                    oo.value++;
                                }
                            if(o.x < maxX && o.y < maxY)
                                if (octopi.Any(oo => oo.x == o.x + 1 && oo.y == o.y + 1 && oo.flashed == false))
                                {
                                    var oo = octopi.First(oo => oo.x == o.x + 1 && oo.y == o.y + 1 && oo.flashed == false);
                                    oo.value++;
                                }
                        }
                    }
                }

                var debug = true;
            }
            Console.WriteLine("Solution 1 is " + flashes);
        }

        static void Part2()
        {

        }
    }

    internal class Octopus
    {
        internal int x;
        internal int y;
        internal bool flashed = false;
        internal int value;
    }
}