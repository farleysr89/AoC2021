using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
        static void Part1()
        {
            string _input = File.ReadAllText("input.txt");
            var entries = _input.Split('\n').ToList();
            int distance = 0;
            int depth = 0;
            foreach (var s in entries)
            {
                if(s != "") { 
                    var parts = s.Split(' ');
                    switch (parts[0])
                    {
                        case "forward":
                            distance += int.Parse(parts[1]);
                            break;
                        case "down":
                            depth += int.Parse(parts[1]);
                            break;
                        case "up":
                            depth -= int.Parse(parts[1]);
                            break;
                        default:
                            Console.WriteLine("Something Broke!");
                            return;
                    }
                }
            }
            Console.WriteLine("solution 1 = " + distance * depth);
        }

        static void Part2()
        {
            string _input = File.ReadAllText("input.txt");
            var entries = _input.Split('\n').ToList();
            int distance = 0;
            int depth = 0;
            int aim = 0;
            foreach (var s in entries)
            {
                if (s != "")
                {
                    var parts = s.Split(' ');
                    switch (parts[0])
                    {
                        case "forward":
                            distance += int.Parse(parts[1]);
                            depth += aim * int.Parse(parts[1]);
                            break;
                        case "down":
                            aim += int.Parse(parts[1]);
                            break;
                        case "up":
                            aim -= int.Parse(parts[1]);
                            break;
                        default:
                            Console.WriteLine("Something Broke!");
                            return;
                    }
                }
            }
            Console.WriteLine("solution 1 = " + distance * depth);
        }
    }
}