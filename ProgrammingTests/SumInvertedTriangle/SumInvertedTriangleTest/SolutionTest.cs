using NUnit.Framework;
using SumInvertedTriangle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumInvertedTriangleTest
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void MaxPathSumTest()
        {
            var obj = new Solution();

            Assert.AreEqual(obj.MaxPathSum(new int[,] { { 1, 5, 3 }, { 4, 8, 0 }, { 1, 0, 0 } }), 14);
        }
    }
}
