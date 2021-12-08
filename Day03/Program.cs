﻿using System;
using System.IO;
using System.Linq;

namespace AoC2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            //Part2();
        }
        
        static void Part1()
        {
            string input = File.ReadAllText("input.txt");
            var entries = input.Split('\n',StringSplitOptions.RemoveEmptyEntries).ToList();
            var length = entries[0].ToString().Length;
            var gammaOutput = "";
            var epsilonOutput = "";
            for(var i = 0; i < length; i++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                foreach(var s in entries)
                {
                    if(s[i] == '0') zeroCount++;
                    else oneCount++;
                }
                gammaOutput += zeroCount > oneCount ? "0" : "1";
                epsilonOutput += zeroCount > oneCount ? "1" : "0";
            }
            Console.WriteLine(Convert.ToInt32(gammaOutput,2) * Convert.ToInt32(epsilonOutput, 2));
        }
    }
    
}