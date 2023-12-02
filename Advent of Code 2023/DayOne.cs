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
    }
}

