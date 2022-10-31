
using System.Collections;
using System.Diagnostics;
using System.IO.Pipes;
using System.Net.Mail;

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
            var input = File.ReadAllText("testInput.txt");
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var Pairs = new List<Pair>();
            foreach (var l in lines)
            {
                //var ll = l.Replace(",","");
                //var count = 0;
                //var newL = "";
                //foreach (var c in l)
                //{
                //    if (c == '[') count++;
                //    if (c == ']') count--;
                //    newL += c;
                //}
                //Pairs.Add(CreateSFN(ll, 1).Item1);
                var sfn = CreateSFN(l);
            }
        }

        static SFN
            CreateSFN(string line)
        {
            //var sfn = new SFN();
            var lB = new List<int>();
            var rB = new List<int>();
            var lBs = new Stack<int>();
            var rBq = new Queue<int>();
            int index = 0;
            var li = 0;
            var ri = 0;
            line = line.Trim();
            line = line[1..^1];
            line = line.Replace(",", "");
            var debug = false;
            var lc = "";
            lc = String.Copy(line);
            SFN sfn = new SFN(null);
            int counter = 1;
            foreach (var c in line)
            {
                if (c == '[')
                {
                    lBs.Push(index);
                    li++;
                }
                else if (c == ']')
                {
                    rBq.Enqueue(index);
                    ri++;
                }
                index++;
                while (li == ri)
                {
                    debug = true;
                    var ai = lBs.Pop() + 1;
                    var bi = rBq.Dequeue() - 1;                    
                    var a = Int32.Parse(Char.ConvertFromUtf32(lc[ai]));
                    var b = Int32.Parse(Char.ConvertFromUtf32(lc[bi]));
                    var p = new Pair(a,b);
                    sfn.pair = new Pair(p, sfn.pair);
                    li--;
                    ri--;
                    lc = lc.Remove(bi + 1,1);
                    lc = lc.Remove(ai - 1,1);
                }
            }
            Console.WriteLine("Left brackets = " + lB);
            Console.WriteLine("Right brackets = " + rB + "\r\n\r\n");
            //var rBsr = new Stack(rBs);
            return sfn;
            //return new Pair(0, 0);
            //var pair = new Pair();
            //for (; i < line.Length; i++)
            //{
            //    if (i == 12)
            //    {
            //        var debug = true;
            //    }
            //    if(line[i] == ']') return (pair, i + 1);
            //    if(line[i] == ',') continue;
            //    else if (line[i] == '[')
            //    {
            //        if(pair.left == null)
            //            (pair.left, i) = CreateSFN(line, i + 1);
            //        else
            //            (pair.right, i) = CreateSFN(line, i + 1);
            //        //i = line.IndexOf(']');
            //    }
            //    else if (int.TryParse(line[i].ToString(), out var num))
            //        if (pair.left == null)
            //            pair.left = new Pair
            //            {
            //                value = num
            //            };
            //        else
            //        {
            //            pair.right = new Pair
            //            {
            //                value = num
            //            };
            //        }
            //    else if (pair.left == null) (pair.left, i) = CreateSFN(line, i + 1);
            //    else (pair.right, i) = CreateSFN(line, i + 1);

            //    if (pair.left != null && pair.right != null) break;
            //}
            ////foreach (var c in line)
            ////{
            ////    if (c == ',') continue;
            ////    if (c == '[') pair.left = CreateSFN(line[(line.IndexOf('[') + 1)..]);
            ////    else if (c == ']') return pair;
            ////    else if (int.TryParse(c.ToString(), out var num))
            ////        if(pair.left == null)
            ////            pair.left = new Pair
            ////            {
            ////                value = num
            ////            };
            ////        else
            ////        {
            ////            pair.right = new Pair
            ////            {
            ////                value = num
            ////            };
            ////        }
            ////    else if(pair.left == null) pair.left = CreateSFN(line[(line.IndexOf(',') + 1)..]);
            ////    else pair.right = CreateSFN(line[(line.IndexOf(',') + 1)..]);

            ////    if (pair.left != null && pair.right != null) break;
            ////}
            //return (pair, i);
        }

        static void Part2()
        {

        }

        static void ExplodeTest()
        {

        }
    }

    internal class SFN
    {
        internal SFN(Pair p)
        {
            pair = p;
        }

        internal Pair? pair;
    }
    internal class Pair
    {
        internal int? leftValue;
        internal int? rightValue;
        internal Pair? left;
        internal Pair? right;

        internal Pair(Pair? p, int? i)
        {
            left = p;
            rightValue = i;
        }

        internal Pair(int? i, Pair? p)
        {
            leftValue = i;
            right = p;
        }

        internal Pair(int? l, int? r)
        {
            leftValue = l;
            rightValue = r;
        }

        internal Pair(Pair? l, Pair? r)
        {
            left = l;
            right = r;
        }
    }
}