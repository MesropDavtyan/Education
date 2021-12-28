namespace ValidAnagram
{
    public class Solution
    {
        public bool IsAnagram(string text, string anagram)
        {
            if (text.Length != anagram.Length)
            {
                return false;
            }

            int[] counts = new int[26];


            for (int i = 0; i < text.Length; i++)
            {
                counts[text[i] - 'a']++;
                counts[anagram[i] - 'a']--;
            }


            foreach (var count in counts)
            {
                if (count != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
