using System.Text.RegularExpressions;

namespace Advent_of_Code_2023
{
	public class DayOne
	{
        /*
        The newly-improved calibration document consists of lines of text;
        each line originally contained a specific calibration value that the Elves now need to recover.
        On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.

        For example:

        1abc2
        pqr3stu8vwx
        a1b2c3d4e5f
        treb7uchet
        In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.

        Consider your entire calibration document. What is the sum of all of the calibration values?
            */

        public static int SumCalibrationValues(string inputFilePath)
        {
            int totalSum = 0;
            string[] textLines = File.ReadAllLines(inputFilePath);

            foreach (var textLine in textLines)
            {
                int firstDigit = int.Parse(new string(textLine.First(char.IsDigit), 1));
                int lastDigit = int.Parse(new string(textLine.Last(char.IsDigit), 1));

                totalSum += firstDigit * 10 + lastDigit;
            }

            return totalSum;
        }

        /*

        --- Part Two ---
        Your calculation isn't quite right.
        It looks like some of the digits are actually spelled out with letters: one, two, three, four, five, six, seven, eight,
        and nine also count as valid "digits".

        Equipped with this new information, you now need to find the real first and last digit on each line. For example:

        two1nine
        eightwothree
        abcone2threexyz
        xtwone3four
        4nineeightseven2
        zoneight234
        7pqrstsixteen
        In this example, the calibration values are 29, 83, 13, 24, 42, 14, and 76. Adding these together produces 281.

        What is the sum of all of the calibration values?

        */

        public static string Helper(string line)
        {
            Dictionary<string, string> numbers = new Dictionary<string, string> {
                { "one",   "1" },
                { "two",   "2" },
                { "three", "3" },
                { "four",  "4" },
                { "five",  "5" },
                { "six",   "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine",  "9" },
            };

            string modifiedLine = string.Empty;

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    modifiedLine += line[i];
                    i++;
                }
            }

            return line;
        }

        public static int SumCalibrationValues2(string inputFilePath)
        {
            Dictionary<string, string> numbers = new Dictionary<string, string> {
                { "one",   "1" },
                { "two",   "2" },
                { "three", "3" },
                { "four",  "4" },
                { "five",  "5" },
                { "six",   "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine",  "9" },
            };

            int totalSum = 0;
            string[] textLines = File.ReadAllLines(inputFilePath);

            foreach (var textLine in textLines)
            {
                string modifiedLine = textLine;

                var indexFirst = -1;
                var numFirst = string.Empty;
                var indexLast = -1;
                var numLast = string.Empty;

                foreach (var number in numbers)
                {
                    if (modifiedLine.Contains(number.Key))
                    {
                        if (indexFirst == -1 || indexFirst > modifiedLine.IndexOf(number.Key))
                        {
                            indexFirst = modifiedLine.IndexOf(number.Key);
                            numFirst = number.Key;
                        }

                        if (indexLast == -1 || indexLast < modifiedLine.IndexOf(number.Key))
                        {
                            indexLast = modifiedLine.IndexOf(number.Key);
                            numLast = number.Key;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(numFirst))
                {
                    modifiedLine = Regex.Replace(modifiedLine, numFirst, numbers[numFirst], RegexOptions.IgnoreCase);
                }
                if (!string.IsNullOrEmpty(numLast))
                {
                    modifiedLine = Regex.Replace(modifiedLine, numLast, numbers[numLast], RegexOptions.IgnoreCase);
                }

                int firstDigit = int.Parse(new string(modifiedLine.First(char.IsDigit), 1));
                int lastDigit = int.Parse(new string(modifiedLine.Last(char.IsDigit), 1));

                totalSum += firstDigit * 10 + lastDigit;
            }

            return totalSum;
        }
    }
}

