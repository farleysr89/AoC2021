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
            List<int> entries = _input.Split('\n').Select(int.Parse).ToList();
            int entry = -1;
            int count = 0;
            foreach (int i in entries)
            {
                if(entry != -1 && i > entry)
                {
                    count++;                    
                }
                entry = i;
            }
            Console.WriteLine("solution = " + count);
        }

        static void Part2()
        {
            string _input = File.ReadAllText("input.txt");
            List<int> entries = _input.Split('\n').Select(int.Parse).ToList();
            int entry = -1;
            int count = 0;
            foreach (int i in entries)
            {
                if (entry != -1 && i > entry)
                {
                    count++;
                }
                entry = i;
            }
            Console.WriteLine("solution = " + count);
        }
    }
}