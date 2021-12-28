using NUnit.Framework;
using ArrayOfMultiples;
using System.Collections.Generic;

namespace ArrayOfMultiplesTest
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void ArrayOfMultiplesTest()
        {
            var solution = new Solution();

            Assert.AreEqual(solution.ArrayOfMultiples(7, 5), new List<int> { 7, 14, 21, 28, 35 });
        }
    }
}
