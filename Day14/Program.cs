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
            var rules = new List<Rule>();
            var polymer = "";
            foreach (var l in lines)
            {
                if (l.Contains("->"))
                {
                    var parts = l.Split(" -> ");
                    rules.Add(new Rule
                    {
                        input = parts[0],
                        output = parts[1]
                    });
                }
                else
                {
                    polymer = l;
                }
            }
            for (var i = 0; i < 10; i++)
            {
                var newPolymer = "";
                for (var j = 0; j < polymer.Length - 1; j++)
                {
                    var pair = polymer.Substring(j, 2);
                    if (rules.Any(r => r.input == pair))
                    {
                        newPolymer += pair[0] + rules.First(r => r.input == pair).output;
                    }
                }

                polymer = newPolymer + polymer[^1];
            }
            var result = polymer.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            Console.WriteLine("Solution 1 is " + (result.Max(r => r.Value) - result.Min(r => r.Value)));
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var rules = new List<Rule>();
            var polymer = "";
            foreach (var l in lines)
            {
                if (l.Contains("->"))
                {
                    var parts = l.Split(" -> ");
                    rules.Add(new Rule
                    {
                        input = parts[0],
                        output = parts[1]
                    });
                }
                else
                {
                    polymer = l;
                }
            }

            var pairs = new Dictionary<string, long>();
            for (var j = 0; j < polymer.Length - 1; j++)
            {
                var pair = polymer.Substring(j, 2);
                pairs.TryGetValue(pair, out var currentCount);
                pairs[pair] = currentCount + 1;
            }
            var charCounts = new Dictionary<char, long>();
            foreach (var c in polymer)
            {
                charCounts.TryGetValue(c, out var currentCount1);
                charCounts[c] = currentCount1 + 1;
            }
            for (var i = 0; i < 40; i++)
            {
                var newPairs = new Dictionary<string, long>();
                foreach (var pair in pairs)
                {
                    if (rules.Any(r => r.input == pair.Key))
                    {
                        var rule = rules.First(r => r.input == pair.Key);
                        var p1 = pair.Key[0] + rule.output;
                        newPairs.TryGetValue(p1, out var currentCount1);
                        newPairs[p1] = currentCount1 + pair.Value;
                        var p2 = rule.output + pair.Key[1];
                        newPairs.TryGetValue(p2, out var currentCount2);
                        newPairs[p2] = currentCount2 + pair.Value;
                        charCounts.TryGetValue(rule.output[0], out var currentCount3);
                        charCounts[rule.output[0]] = currentCount3 + pair.Value;
                    }
                }

                pairs = new Dictionary<string, long>(newPairs);
            }
            
            Console.WriteLine("Solution 2 is " + (charCounts.Max(r => r.Value) - charCounts.Min(r => r.Value)));
        }
    }

    internal class Rule
    {
        internal string input;
        internal string output;
    }
}