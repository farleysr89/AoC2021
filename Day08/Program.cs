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
            var outputs = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var parts = outputs.Select(o => o.Split(" | ")).Select(s => s[1]).SelectMany(s => s.Split(" ")).ToList();
            var count = parts.Count(o => o.Length is 2 or 3 or 4 or 7);
            Console.WriteLine("Solution 1 = " + count);
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var inputs = lines.Select(o => o.Split(" | ")).Select(s => s[0]).ToList();
            var outputs = lines.Select(o => o.Split(" | ")).Select(s => s[1]).ToList();

            var total = 0;

            for (var i = 0; i < inputs.Count; i++)
            {
                string one = "", two = "", three = "", four = "", five = "", six = "", seven = "", eight = "", nine = "", zero = "";
                char t = '\0', b = '\0', ur = '\0', lr = '\0', ul = '\0', ll = '\0', m = '\0';
                var parts = inputs[i].Split(" ").ToList();
                if (parts.Any(p => p.Length == 2))
                    one = parts.First(p => p.Length == 2);
                if (parts.Any(p => p.Length == 3))
                    seven = parts.First(p => p.Length == 3);
                if (parts.Any(p => p.Length == 4))
                    four = parts.First(p => p.Length == 4);
                if (parts.Any(p => p.Length == 7))
                    eight = parts.First(p => p.Length == 7);
                if (one != "" && seven != "")
                {
                    t = seven.First(c => !one.Contains(c));
                }

                if (one != "" && parts.Any(p => p.Length == 6 && p.Contains(four[0]) && p.Contains(four[1]) && p.Contains(four[2]) && p.Contains(four[3])))
                {
                    nine = parts.First(p => p.Length == 6 && p.Contains(four[0]) && p.Contains(four[1]) && p.Contains(four[2]) && p.Contains(four[3]));
                }

                if (nine != "" && parts.Any(p => p.Length == 6 && p != nine && (p.Contains(one[0]) ^ p.Contains(one[1]))))
                {
                    six = parts.First(p => p.Length == 6 && p != nine && (p.Contains(one[0]) ^ p.Contains(one[1])));
                    if (six.Contains(one[0])) ur = one[1];
                    else ur = one[0];
                }

                if (nine != "" && six != "" && parts.Any(p => p.Length == 6 && p != nine && p != six))
                {
                    zero = parts.First(p => p.Length == 6 && p != nine && p != six);
                }

                var chars = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
                if (zero != "")
                {
                    m = chars.Except(zero.ToCharArray()).First();
                }

                if (t != '\0' && m != '\0' && one != "")
                {
                    if (parts.Any(p =>
                            p.Length == 5 && p.Contains(t) && p.Contains(m) && p.Contains(one[0]) &&
                            p.Contains(one[1])))
                    {
                        three = parts.First(p =>
                            p.Length == 5 && p.Contains(t) && p.Contains(m) && p.Contains(one[0]) &&
                            p.Contains(one[1]));
                    }
                }

                if (three != "" && parts.Any(p => p.Length == 5 && p != three && p.Contains(ur)))
                {
                    two = parts.First(p => p.Length == 5 && p != three && p.Contains(ur));
                }
                if (three != "" && two != "" && parts.Any(p => p.Length == 5 && p != three && p!= two))
                {
                    five = parts.First(p => p.Length == 5 && p != three && p != two);
                }

                var value = "";
                one = string.Concat(one.OrderBy(c => c));
                two = string.Concat(two.OrderBy(c => c));
                three = string.Concat(three.OrderBy(c => c));
                four = string.Concat(four.OrderBy(c => c));
                five = string.Concat(five.OrderBy(c => c));
                six = string.Concat(six.OrderBy(c => c));
                seven = string.Concat(seven.OrderBy(c => c));
                eight = string.Concat(eight.OrderBy(c => c));
                nine = string.Concat(nine.OrderBy(c => c));
                zero = string.Concat(zero.OrderBy(c => c));
                foreach (var s in outputs[i].Split(" ").Select(s => string.Concat(s.OrderBy(c => c))))
                {
                    if (s == one) value += "1";
                    else if (s == two) value += "2";
                    else if (s == three) value += "3";
                    else if (s == four) value += "4";
                    else if (s == five) value += "5";
                    else if (s == six) value += "6";
                    else if (s == seven) value += "7";
                    else if (s == eight) value += "8";
                    else if (s == nine) value += "9";
                    else if (s == zero) value += "0";
                }

                if (value.Length == 4)
                {
                    total += Convert.ToInt32(value);
                    //Console.WriteLine("Value for " + i + " is " + value);
                }
                else
                {
                    throw new Exception("Something Broke!");
                }
            }
            Console.WriteLine("Solution 2 = " + total);
        }
    }
}