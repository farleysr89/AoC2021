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
            var total = 0;
            for (var i = 0; i < outputs.Count; i++)
            {
                for (var j = 0; j < outputs[i].Length; j++)
                {
                    var k = Convert.ToInt32(outputs[i][j].ToString());
                    if (i != 0)
                    {
                        if (Convert.ToInt32(outputs[i - 1][j].ToString()) <= k) continue;
                    }

                    if (j != 0)
                    {
                        if (Convert.ToInt32(outputs[i][j - 1].ToString()) <= k) continue;
                    }

                    if (i != outputs.Count - 1)
                    {
                        if (Convert.ToInt32(outputs[i + 1][j].ToString()) <= k) continue;
                    }

                    if (j != outputs[i].Length - 1)
                    {
                        if (Convert.ToInt32(outputs[i][j + 1].ToString()) <= k) continue;
                    }

                    total += k + 1;
                }
            }

            Console.WriteLine("Solution 1 is " + total);
        }

        static void Part2()
        {

        }
    }
}