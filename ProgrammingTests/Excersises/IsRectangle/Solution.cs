using System;

namespace IsRectangle
{
    public class Solution
    {
        public bool IsRectangle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            var firstDiagonal = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
            var secondDiagonal = Math.Sqrt(Math.Pow(x4 - x2, 2) + Math.Pow(y4 - y2, 2));

            return firstDiagonal == secondDiagonal ? true : false;
        }
    }
}
