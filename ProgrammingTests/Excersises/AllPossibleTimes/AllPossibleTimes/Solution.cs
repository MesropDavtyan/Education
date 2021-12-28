using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Tvaca 4 hat tiv A, B, C, D. 
    Gri funkcia vor2 kveradarcni et te et 4 tvov hnaravor qani hat jami representation ka 24 jamanoc formatov.
*/

namespace AllPossibleTimes
{
    public class Solution
    {
        public HashSet<int> GetAllPossibleTimes(int a, int b, int c, int d)
        {
            int[] arr = { a, b, c, d };
            HashSet<int> myList = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= 2)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[i] == 1 || arr[j] <= 3)
                        {
                            for (int k = 0; k < arr.Length; k++)
                            {
                                if (arr[k] <= 5)
                                {
                                    for (int l = 0; l < arr.Length; l++)
                                    {
                                        if (i != j && i != k && i != l && j != k && j != l && k != l && arr[l] <= 9)
                                        {
                                            myList.Add(arr[i] * 1000 + arr[j] * 100 + arr[k] * 10 + arr[l]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return myList;
        }
    }
}
