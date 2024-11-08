﻿using System.Text.RegularExpressions;

namespace Advent_of_Code_2023
{
    public class TreeNode
    {
        public string val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(string val = "", TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class DayEight
	{
		/*

		It seems like you're meant to use the left/right instructions to navigate the network.
		Perhaps if you have the camel follow the same instructions, you can escape the haunted wasteland!

		After examining the maps for a bit, two nodes stick out: AAA and ZZZ.
		You feel like AAA is where you are now, and you have to follow the left/right instructions until you reach ZZZ.

		This format defines each node of the network individually. For example:

		RL

		AAA = (BBB, CCC)
		BBB = (DDD, EEE)
		CCC = (ZZZ, GGG)
		DDD = (DDD, DDD)
		EEE = (EEE, EEE)
		GGG = (GGG, GGG)
		ZZZ = (ZZZ, ZZZ)
		Starting with AAA, you need to look up the next element based on the next left/right instruction in your input.
		In this example, start with AAA and go right (R) by choosing the right element of AAA, CCC.
		Then, L means to choose the left element of CCC, ZZZ. By following the left/right instructions, you reach ZZZ in 2 steps.

		Of course, you might not find ZZZ right away. If you run out of left/right instructions,
		repeat the whole sequence of instructions as necessary: RL really means RLRLRLRLRLRLRLRL... and so on.
		For example, here is a situation that takes 6 steps to reach ZZZ:

		LLR

		AAA = (BBB, BBB)
		BBB = (AAA, ZZZ)
		ZZZ = (ZZZ, ZZZ)
		Starting at AAA, follow the left/right instructions. How many steps are required to reach ZZZ?

		*/

		public static int HauntedWasteland(string inputFilePath)
		{
			int waysToBeatTheRecord = 1;

			string[] textLines = File.ReadAllLines(inputFilePath);
            string directionSequance = textLines[0];

            TreeNode root = null;

            for (int i = 2; i < textLines.Length; i++)
			{
				var rootValue = textLines[i].Substring(0, 3).Trim();
				var leftValue = textLines[i].Substring(textLines[i].LastIndexOf("(") + 1, 3);
				var rightValue = textLines[i].Substring(textLines[i].LastIndexOf(",") + 2, 3);

				if (root == null)
				{
					root = new TreeNode(rootValue, new TreeNode(leftValue), new TreeNode(rightValue));
                }
            }

            return waysToBeatTheRecord;
		}

		public TreeNode TreeConstructor()
		{

		}


		/*


		*/
	}
}
