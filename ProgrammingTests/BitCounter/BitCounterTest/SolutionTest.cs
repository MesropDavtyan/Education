using BitCounter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCounterTest
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void BitSummerTest()
        {
            var solution = new Solution();
            Assert.AreEqual(solution.BitSummer(5), 2);
        }
    }
}
