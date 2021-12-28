using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SumInvertedTriangle
{
    public class Solution
    {
        public int MaxPathSum(int[,] triangle)
        {
            var sum = 0;

            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                var max = 0;

                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    if (triangle[i, j] > max)
                    {
                        max = triangle[i, j];
                    }
                    Console.WriteLine(max);
                }
                sum += max;
            }

            return sum;
        }

        public int MaxPathSum2(int[,] tri)
        {
            //int N = 3;
            int ans = 0;

            // Loop for bottom-up calculation 
            for (int i = tri.GetLength(0) - (tri.GetLength(0) - 1); i >= 0; i--)
            {
                for (int j = 0; j < tri.GetLength(1) - i; j++)
                {
                    // For each element, check both 
                    // elements just below the number 
                    // and below left to the number 
                    // add the maximum of them to it 
                    if (j - 1 >= 0)
                        tri[i, j] += Math.Max(tri[i + 1, j],
                                        tri[i + 1, j - 1]);
                    else
                        tri[i, j] += tri[i + 1, j];

                    ans = Math.Max(ans, tri[i, j]);
                }
            }

            // Return the maximum sum 
            return ans;
        }

        public int Foo(int num1, int num2)
        {
            IList<string> stringList = new List<string>() {
                    "C# Tutorials",
                    "VB.NET Tutorials",
                    "Learn C++",
                    "MVC Tutorials" ,
                    "Java"
            };

            var a = stringList.Where(x => x.Contains('C'));

            Hashtable ht = new Hashtable();
            ht.Add(1, "Aram");
            ht.Add(2, "Gevorg");
            ht.Add(3, "Vazgen");

            ht[3] = "Aharon"; 

            try
            {
                return num1 / num2;
            }
            catch (DivideByZeroException ex)
            {
                throw;
            }
        }

        public int Foo2(int num1, int num2) => num1 / num2;


        //Write a short program which takes an integer and outputs the number of 1`s in this integer`s equivalent in binary system by using bit shift operator >>. 
        //For example 5 is 101 and there are 2 times "1" in it.

        public void Foo3(int num)
        {
            List<int> intList = new List<int> { 1, 5, 13, 48, 115 };

            foreach (var item in Foo4(intList))
            {
                Console.WriteLine(item);
            }
            //var a = num >> 1;
            //return a;
        }

        private IEnumerable<int> Foo4(List<int> myList)
        {
            Mutex mutex = new Mutex();
            mutex.WaitOne();
            mutex.ReleaseMutex();

            foreach (var item in myList)
            {
                if (item > 20)
                {
                    yield return item;
                }
            }
        }
    }
}
