using System.Diagnostics.CodeAnalysis;

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
            //var binary = Convert.ToString(Convert.ToInt32(input, 16), 2);
            string binary = String.Join(String.Empty,
                input.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                )
            );
            var index = 0;
            var end = false;
            var number = "";
            var sum = ProcessPacket(binary, 0);
            //while (!end)
            //{
            //    var version = int.Parse(Convert.ToString(Convert.ToInt32(binary.Substring(index, 3), 2), 10));
            //    index += 3;
            //    var id = int.Parse(Convert.ToString(Convert.ToInt32(binary.Substring(index, 3), 2), 10));
            //    index += 3;
            //    while (!end)
            //    {
            //        var part = binary.Substring(index, 5);
            //        number += part[1..];
            //        if (part[0] == '0') end = true;
            //        index += 5;
            //    }
            //    break;
            //}
            Console.WriteLine("Solution 1 is " + sum.Item1);
        }

        static (int, int) ProcessPacket(string binary, int index, int size = -1)
        {
            var end = false;
            var init = index;
            //var number = "";
            var sum = 0;
            var version = int.Parse(Convert.ToString(Convert.ToInt32(binary.Substring(index, 3), 2), 10));
            sum += version;
            index += 3;
            var id = int.Parse(Convert.ToString(Convert.ToInt32(binary.Substring(index, 3), 2), 10));
            index += 3;
            if (id == 4)
            {
                while (!end)
                {
                    //var part = binary.Substring(index, 5);
                    //number += part[1..];
                    if (binary[index] == '0') end = true;
                    index += 5;
                }
            }
            else
            {
                var lengthId = binary[index];
                index++;
                if (lengthId == '0')
                {
                    var length = int.Parse(Convert.ToString(Convert.ToInt32(binary.Substring(index, 15), 2), 10));
                    index += 15;
                    var target = index + length;
                    while (index < target)
                    {
                        var (a, b) = ProcessPacket(binary, index, length);
                        sum += a;
                        index = b;
                    }
                }
                else if (lengthId == '1')
                {
                    var count = int.Parse(Convert.ToString(Convert.ToInt32(binary.Substring(index, 11), 2), 10));
                    index += 11;
                    //var target = index + length;
                    for(var i = 0; i < count; i++)
                    {
                        var (a, b) = ProcessPacket(binary, index);
                        sum += a;
                        index = b;
                    }
                }
                else
                {
                    throw new Exception("Something Broke!");
                }

            }

            //sum += Convert.ToInt32(number, 2);
            
            return (sum, index);
        }

        static void Part2()
        {

        }
    }
}