using System.Text.RegularExpressions;

namespace Advent_of_Code_2023
{
	public class DayThree
	{
		public static int GearRatios(string inputFilePath)
		{
			int sum = 0;

			return sum;
		}

        public static int CalculatePartNumberSum(string filePath)
        {
            var (grid, symbol) = Read(filePath);
            var adjacent = GetAdjacency(grid, symbol);
            return CalculateResult(grid, adjacent);
        }

        static (List<List<char>>, List<(int, int)>) Read(string path)
        {
            var grid = new List<List<char>>();
            var symbol = new List<(int, int)>();

            using (var file = new StreamReader(path))
            {
                string line;
                int row = 0;

                while ((line = file.ReadLine()) != null)
                {
                    var rowList = new List<char>(line.Trim());
                    grid.Add(rowList);

                    for (int col = 0; col < rowList.Count; col++)
                    {
                        if (!char.IsDigit(rowList[col]) && rowList[col] != '.')
                        {
                            symbol.Add((row, col));
                        }
                    }

                    row++;
                }
            }

            return (grid, symbol);
        }

        static HashSet<(int, int)> GetAdjacency(List<List<char>> grid, List<(int, int)> symbol)
        {
            var adjacent = new HashSet<(int, int)>();
            int rows = grid.Count;
            int cols = grid[0].Count;

            foreach (var (row, col) in symbol)
            {
                if (grid[row][col] == '.')
                {
                    continue;
                }

                for (int adjacentCol = Math.Max(0, col - 1); adjacentCol <= Math.Min(cols - 1, col + 1); adjacentCol++)
                {
                    if (char.IsDigit(grid[row][adjacentCol]))
                    {
                        adjacent.Add((row, adjacentCol));
                    }
                }

                foreach (var adjacentRow in new[] { row - 1, row + 1 })
                {
                    if (0 <= adjacentRow && adjacentRow < rows)
                    {
                        for (int adjacentCol = Math.Max(0, col - 1); adjacentCol <= Math.Min(cols - 1, col + 1); adjacentCol++)
                        {
                            if (char.IsDigit(grid[adjacentRow][adjacentCol]))
                            {
                                adjacent.Add((adjacentRow, adjacentCol));
                            }
                        }
                    }
                }
            }

            return adjacent;
        }

        static int CalculateResult(List<List<char>> grid, HashSet<(int, int)> adjacent)
        {
            int total = 0;
            Regex pattern = new Regex(@"\d+");

            for (int row = 0; row < grid.Count; row++)
            {
                string rowData = new string(grid[row].ToArray());

                foreach (Match foundMatch in pattern.Matches(rowData))
                {
                    int firstPos = foundMatch.Index;
                    int lastPos = foundMatch.Index + foundMatch.Length - 1;

                    if (Enumerable.Range(firstPos, lastPos - firstPos + 1).Any(col => adjacent.Contains((row, col))))
                    {
                        total += int.Parse(foundMatch.Value);
                    }
                }
            }

            return total;
        }

    }
}

