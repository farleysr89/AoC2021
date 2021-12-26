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
            var binary = string.Join(string.Empty,
                input.Select(
                    c => Convert.ToString(Convert.ToInt64(c.ToString(), 16), 2).PadLeft(4, '0')
                )
            );
            var sum = ProcessPacket(binary, 0);
            Console.WriteLine("Solution 1 is " + sum.Item1);
        }

        static (long, int) ProcessPacket(string binary, int index, long size = -1)
        {
            var end = false;
            long sum = 0;
            var version = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 3), 2), 10));
            sum += version;
            index += 3;
            var id = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 3), 2), 10));
            index += 3;
            if (id == 4)
            {
                while (!end)
                {
                    if (binary[index] == '0') end = true;
                    index += 5;
                }
            }
            else
            {
                var lengthId = binary[index];
                index++;
                switch (lengthId)
                {
                    case '0':
                    {
                        var length = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 15), 2), 10));
                        index += 15;
                        var target = index + length;
                        while (index < target)
                        {
                            var (a, b) = ProcessPacket(binary, index, length);
                            sum += a;
                            index = b;
                        }

                        break;
                    }
                    case '1':
                    {
                        var count = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 11), 2), 10));
                        index += 11;
                        for(var i = 0; i < count; i++)
                        {
                            var (a, b) = ProcessPacket(binary, index);
                            sum += a;
                            index = b;
                        }

                        break;
                    }
                    default:
                        throw new Exception("Something Broke!");
                }

            }

            return (sum, index);
        }

        static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var binary = string.Join(string.Empty,
                input.Select(
                    c => Convert.ToString(Convert.ToInt64(c.ToString(), 16), 2).PadLeft(4, '0')
                )
            );
            var sum = ProcessPacket2(binary, 0);
            Console.WriteLine("Solution 1 is " + sum.Item1);
        }

        static (long, int) ProcessPacket2(string binary, int index, long size = -1)
        {
            var end = false;
            var init = index;
            var number = "";
            long sum = 0;
            var version = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 3), 2), 10));
            index += 3;
            var id = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 3), 2), 10));
            index += 3;
            switch (id)
            {
                case 0:
                {
                    sum = 0;
                    var lengthId = binary[index];
                    index++;
                    switch (lengthId)
                    {
                        case '0':
                        {
                            var length = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 15), 2), 10));
                            index += 15;
                            var target = index + length;
                            while (index < target)
                            {
                                var (a, b) = ProcessPacket2(binary, index, length);
                                sum += a;
                                index = b;
                            }

                            break;
                        }
                        case '1':
                        {
                            var count = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 11), 2), 10));
                            index += 11;
                            for(var i = 0; i < count; i++)
                            {
                                var (a, b) = ProcessPacket2(binary, index);
                                sum += a;
                                index = b;
                            }

                            break;
                        }
                        default:
                            throw new Exception("Something Broke!");
                    }

                    return (sum, index);
                }
                case 1:
                {
                    sum = 1;
                    var lengthId = binary[index];
                    index++;
                    switch (lengthId)
                    {
                        case '0':
                        {
                            var length = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 15), 2), 10));
                            index += 15;
                            var target = index + length;
                            while (index < target)
                            {
                                var (a, b) = ProcessPacket2(binary, index, length);
                                sum *= a;
                                index = b;
                            }

                            break;
                        }
                        case '1':
                        {
                            var count = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 11), 2), 10));
                            index += 11;
                            for(var i = 0; i < count; i++)
                            {
                                var (a, b) = ProcessPacket2(binary, index);
                                sum *= a;
                                index = b;
                            }

                            break;
                        }
                        default:
                            throw new Exception("Something Broke!");
                    }

                    return (sum, index);
                }
                case 2:
                {
                    sum = long.MaxValue;
                    var lengthId = binary[index];
                    index++;
                    switch (lengthId)
                    {
                        case '0':
                        {
                            var length = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 15), 2), 10));
                            index += 15;
                            var target = index + length;
                            while (index < target)
                            {
                                var (a, b) = ProcessPacket2(binary, index, length);
                                sum = Math.Min(a,sum);
                                index = b;
                            }

                            break;
                        }
                        case '1':
                        {
                            var count = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 11), 2), 10));
                            index += 11;
                            for(var i = 0; i < count; i++)
                            {
                                var (a, b) = ProcessPacket2(binary, index);
                                sum = Math.Min(a,sum);
                                index = b;
                            }

                            break;
                        }
                        default:
                            throw new Exception("Something Broke!");
                    }

                    return (sum, index);
                }
                case 3:
                {
                    sum = long.MinValue;
                    var lengthId = binary[index];
                    index++;
                    switch (lengthId)
                    {
                        case '0':
                        {
                            var length = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 15), 2), 10));
                            index += 15;
                            var target = index + length;
                            while (index < target)
                            {
                                var (a, b) = ProcessPacket2(binary, index, length);
                                sum = Math.Max(a,sum);
                                index = b;
                            }

                            break;
                        }
                        case '1':
                        {
                            var count = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 11), 2), 10));
                            index += 11;
                            for(var i = 0; i < count; i++)
                            {
                                var (a, b) = ProcessPacket2(binary, index);
                                sum = Math.Max(a,sum);
                                index = b;
                            }

                            break;
                        }
                        default:
                            throw new Exception("Something Broke!");
                    }

                    return (sum, index);
                }
                case 4:
                {
                    while (!end)
                    {
                        var part = binary.Substring(index, 5);
                        if (part[0] == '0') end = true;
                        number += part[1..];
                        index += 5;
                    }
                    return (Convert.ToInt64(number, 2), index);
                }
                case 5:
                {
                    sum = long.MinValue;
                    var values = new List<long>();
                    var lengthId = binary[index];
                    index++;
                    switch (lengthId)
                    {
                        case '0':
                        {
                            var length = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 15), 2), 10));
                            index += 15;
                            var target = index + length;
                            while (index < target)
                            {
                                var (a, b) = ProcessPacket2(binary, index, length);
                                values.Add(a);
                                index = b;
                            }

                            break;
                        }
                        case '1':
                        {
                            var count = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 11), 2), 10));
                            index += 11;
                            for(var i = 0; i < count; i++)
                            {
                                var (a, b) = ProcessPacket2(binary, index);
                                values.Add(a);
                                index = b;
                            }

                            break;
                        }
                        default:
                            throw new Exception("Something Broke!");
                    }

                    return (values[0] > values[1] ? 1 : 0, index);
                }
                case 6:
                {
                    sum = long.MinValue;
                    var values = new List<long>();
                    var lengthId = binary[index];
                    index++;
                    switch (lengthId)
                    {
                        case '0':
                        {
                            var length = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 15), 2), 10));
                            index += 15;
                            var target = index + length;
                            while (index < target)
                            {
                                var (a, b) = ProcessPacket2(binary, index, length);
                                values.Add(a);
                                index = b;
                            }

                            break;
                        }
                        case '1':
                        {
                            var count = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 11), 2), 10));
                            index += 11;
                            for(var i = 0; i < count; i++)
                            {
                                var (a, b) = ProcessPacket2(binary, index);
                                values.Add(a);
                                index = b;
                            }

                            break;
                        }
                        default:
                            throw new Exception("Something Broke!");
                    }

                    return (values[0] < values[1] ? 1 : 0, index);
                }
                case 7:
                {
                    sum = long.MinValue;
                    var values = new List<long>();
                    var lengthId = binary[index];
                    index++;
                    switch (lengthId)
                    {
                        case '0':
                        {
                            var length = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 15), 2), 10));
                            index += 15;
                            var target = index + length;
                            while (index < target)
                            {
                                var (a, b) = ProcessPacket2(binary, index, length);
                                values.Add(a);
                                index = b;
                            }

                            break;
                        }
                        case '1':
                        {
                            var count = long.Parse(Convert.ToString(Convert.ToInt64(binary.Substring(index, 11), 2), 10));
                            index += 11;
                            for(var i = 0; i < count; i++)
                            {
                                var (a, b) = ProcessPacket2(binary, index);
                                values.Add(a);
                                index = b;
                            }

                            break;
                        }
                        default:
                            throw new Exception("Something Broke!");
                    }

                    return (values[0] == values[1] ? 1 : 0, index);
                }
                default:
                    throw new Exception("Something Broke!");
            }
        }
    }
}