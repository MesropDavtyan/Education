using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Solution2
    {
        public bool OCRValidator(string S, string T)
        {
            S = ParseOCRString(S);
            T = ParseOCRString(T);

            if (S.Length != T.Length)
            {
                return false;
            }

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] != '?' && T[i] != '?' && S[i] != T[i])
                {
                    return false;
                }
            }

            return true;
        }

        public string ParseOCRString(string S)
        {
            StringBuilder tS = new StringBuilder();

            foreach (var character in S)
            {
                if (char.IsNumber(character))
                {
                    for (int i = 0; i < (character - '0'); i++)
                    {
                        tS.Append('?');
                    }
                }
                else
                {
                    tS.Append(character);
                }
            }

            return tS.ToString();
        }
    }
}
