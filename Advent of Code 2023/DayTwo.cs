﻿namespace Advent_of_Code_2023
{
	public class DayTwo
	{
		private const string Red = "red";
		private const string Green = "green";
		private const string Blue = "blue";

		/*

		You play several games and record the information from each game (your puzzle input). 
		Each game is listed with its ID number (like the 11 in Game 11: ...) 
		followed by a semicolon-separated list of subsets of cubes that were revealed from the bag (like 3 red, 5 green, 4 blue).

		For example, the record of a few games might look like this:

		Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
		Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
		Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
		Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
		Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green

		In game 1, three sets of cubes are revealed from the bag (and then put back again).
		The first set is 3 blue cubes and 4 red cubes; the second set is 1 red cube, 2 green cubes, and 6 blue cubes; the third set is only 2 green cubes.

		The Elf would first like to know which games would have been possible if the bag contained only 12 red cubes, 13 green cubes, and 14 blue cubes?

		In the example above, games 1, 2, and 5 would have been possible if the bag had been loaded with that configuration.
		However, game 3 would have been impossible because at one point the Elf showed you 20 red cubes at once; similarly,
		game 4 would also have been impossible because the Elf showed you 15 blue cubes at once.
		If you add up the IDs of the games that would have been possible, you get 8.

		Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes.
		What is the sum of the IDs of those games?

		*/

		public static int CubeConundrum(string inputFilePath)
		{
			int sum = 0;
			Dictionary<string, int> possibleGameValues = new Dictionary<string, int>
			{
				{ Red,   12 },
				{ Green, 13 },
				{ Blue,  14 }
			};

			string[] textLines = File.ReadAllLines(inputFilePath);

			for (int i = 0; i < textLines.Length; i++)
			{
				Dictionary<string, int> gameValues = new Dictionary<string, int>
				{
					{ Red,   0},
					{ Green, 0},
					{ Blue,  0}
				};
				// to remove Game x: part from the line
				string modifiedLine = textLines[i].Substring(textLines[i].LastIndexOf(":") + 2);

				// to split line int the array of numbers and colors, e.g. {"3", "blue", "7", "green", "10", "red", ...}
				string[] splittedLine = modifiedLine.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

				for (int j = 0; j < splittedLine.Length; j++)
				{
					gameValues[splittedLine[j + 1]] = Math.Max(Int32.Parse(splittedLine[j]), gameValues[splittedLine[j + 1]]);

					j++;
				}

				if (gameValues[Red] <= possibleGameValues[Red] &&
					gameValues[Blue] <= possibleGameValues[Blue] &&
					gameValues[Green] <= possibleGameValues[Green])
				{
					sum += i + 1;
				}
			}

			return sum;
		}

		/*

		--- Part Two ---
		In each game you played, what is the fewest number of cubes of each color that could have been in the bag to make the game possible?

		Again consider the example games from earlier:

		Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
		Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
		Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
		Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
		Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green

		In game 1, the game could have been played with as few as 4 red, 2 green, and 6 blue cubes.
		If any color had even one fewer cube, the game would have been impossible.
		Game 2 could have been played with a minimum of 1 red, 3 green, and 4 blue cubes.
		Game 3 must have been played with at least 20 red, 13 green, and 6 blue cubes.
		Game 4 required at least 14 red, 3 green, and 15 blue cubes.
		Game 5 needed no fewer than 6 red, 3 green, and 2 blue cubes in the bag.
		The power of a set of cubes is equal to the numbers of red, green, and blue cubes multiplied together.
		The power of the minimum set of cubes in game 1 is 48. In games 2-5 it was 12, 1560, 630, and 36, respectively.
		Adding up these five powers produces the sum 2286.

		For each game, find the minimum set of cubes that must have been present. What is the sum of the power of these sets?

		*/

		public static int CubeConundrumPartTwo(string inputFilePath)
		{
			int sum = 0;

			string[] textLines = File.ReadAllLines(inputFilePath);

			for (int i = 0; i < textLines.Length; i++)
			{
				Dictionary<string, int> gameValues = new Dictionary<string, int>
				{
					{ Red,   0},
					{ Green, 0},
					{ Blue,  0}
				};

				// to remove Game x: part from the line
				string modifiedLine = textLines[i].Substring(textLines[i].LastIndexOf(":") + 2);

				// to split line int the array of numbers and colors, e.g. {"3", "blue", "7", "green", "10", "red", ...}
				string[] splittedLine = modifiedLine.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

				for (int j = 0; j < splittedLine.Length; j++)
				{
					gameValues[splittedLine[j + 1]] = Math.Max(Int32.Parse(splittedLine[j]), gameValues[splittedLine[j + 1]]);

					j++;
				}

				sum += gameValues[Red] * gameValues[Green] * gameValues[Blue];
			}

			return sum;
		}
	}
}

