using NUnit.Framework;
using RomanToNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanToNumberTest
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void RomanToNumberTest()
        {
            var solution = new Solution();

            Assert.AreEqual(solution.RomanToNumber("mCMXCIII"), 1993);
        }
    }
}
