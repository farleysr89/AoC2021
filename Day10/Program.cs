using System.Collections;

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
            var score = 0;
            foreach (var line in lines)
            {
                var found = false;
                var stack = new Stack<char>();
                foreach (var c in line.TakeWhile(c => !found))
                {
                    char cc;
                    switch (c)
                    {
                        case('('):
                            stack.Push(c);
                            break;
                        case(')'):
                            cc = stack.Pop();
                            if (cc != '(')
                            {
                                score += 3;
                                found = true;
                            }
                            break;
                        case('['):
                            stack.Push(c);
                            break;
                        case(']'):
                            cc = stack.Pop();
                            if (cc != '[')
                            {
                                score += 57;
                                found = true;
                            }
                            break;
                        case('<'):
                            stack.Push(c);
                            break;
                        case('>'):
                            cc = stack.Pop();
                            if (cc != '<')
                            {
                                score += 25137;
                                found = true;
                            }
                            break;
                        case('{'):
                            stack.Push(c);
                            break;
                        case('}'):
                            cc = stack.Pop();
                            if (cc != '{')
                            {
                                score += 1197;
                                found = true;
                            }
                            break;
                        default:
                            throw new Exception("Something Broke!");
                    }
                }
            }
            Console.WriteLine("Solution 1 is " + score);
        }

        static void Part2()
        {

        }
    }
}