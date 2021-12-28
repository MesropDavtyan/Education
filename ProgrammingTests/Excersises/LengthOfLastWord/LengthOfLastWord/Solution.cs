namespace LengthOfLastWord
{
    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            int length = 0;
            int index = s.Length - 1;

            while (index >= 0)
            {
                if (s[index--] != ' ')
                {
                    length++;
                }
                else if (length > 0)
                {
                    return length;
                }
            }

            return length;
        }
    }
}
