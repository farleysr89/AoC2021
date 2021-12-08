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
            string input = File.ReadAllText("input.txt");
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            var numbersToCall = entries[0].Split(',').Select(n => Convert.ToInt32(n));
            var boards = new List<Board>();

            for (var i = 1; i < entries.Count; i++)
            {
                var board = new Board()
                {
                    id = boards.Count
                };
                for (var j = 0; j < 6; j++)
                {
                    if(j == 0) continue;
                    var row = entries[i + j].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var col = 0;
                    foreach (var c in row)
                    {
                        board.cells.Add(new Cell()
                        {
                            row = j - 1,
                            col = col,
                            value = Convert.ToInt32(c),
                            marked = false
                        });
                        col++;
                    }
                }
                boards.Add(board);
                i += 5;
            }

            foreach (var num in numbersToCall)
            {
                foreach (var b in boards)
                {
                    if (b.cells.Any(c => c.value == num))
                    {
                        b.cells.Where(c => c.value == num).Select(c =>
                        {
                            c.marked = true;
                            return c;
                        }).ToList();
                        if (b.checkForWin())
                        {
                            Console.WriteLine("Victory found with number " + num + " on board " + b.id);
                            var unMarked = b.cells.Where(c => !c.marked).Sum(c => c.value);
                            Console.WriteLine("Solution 1 = " + unMarked * num);
                            return;
                        }
                    }
                }
            }
        }

        static void Part2()
        {
            string input = File.ReadAllText("input.txt");
            var entries = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }

    class Cell
    {
        internal int value;
        internal int row;
        internal int col;
        internal bool marked;
    }

    class Board
    {
        internal List<Cell> cells = new();
        internal int id;

        internal bool checkForWin()
        {
            var rows = cells.Where(c => c.marked).GroupBy(c => c.row);
            if (rows.Any(r => r.Count() == 5)) return true;
            var cols = cells.Where(c => c.marked).GroupBy(c => c.col);
            if (cols.Any(r => r.Count() == 5)) return true;
            return false;
        }
    }
}