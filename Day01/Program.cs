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
            Console.WriteLine("solution 1 = " + count);
        }

        static void Part2()
        {
            string _input = File.ReadAllText("input.txt");
            List<int> entries = _input.Split('\n').Select(int.Parse).ToList();
            int runningSum = 0;
            int nextSum = 0;
            int count = 0;
            var addCount = 0;
            foreach (int i in entries)
            {
                if(addCount < 3)
                {
                    runningSum += i;
                    addCount++;
                    nextSum = runningSum;
                    continue;
                }
                nextSum += i;
                nextSum -= entries[addCount - 3];
                if(nextSum > runningSum)
                    count++;
                nextSum = runningSum;
                addCount++;
                runningSum = nextSum;
            }
            Console.WriteLine("solution 2 = " + count);
        }
    }
}