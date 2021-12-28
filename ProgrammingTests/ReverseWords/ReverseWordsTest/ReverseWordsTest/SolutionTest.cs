using NUnit.Framework;
using ReverseWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordsTest
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void ReverseWordsTest()
        {
            var solution = new Solution();

            Assert.AreEqual(solution.ReverseWordsOptimal("hello"), "hello");
            Assert.AreEqual(solution.ReverseWordsOptimal("hello world"), "world hello");
            Assert.AreEqual(solution.ReverseWordsOptimal("this is nice day"), "day nice is this");
            Assert.AreEqual(solution.ReverseWordsOptimal("this\tis\tnice\tday"), "day nice is this");
            Assert.AreEqual(solution.ReverseWordsOptimal("this  is nice \t day"), "day nice is this");
            Assert.AreEqual(solution.ReverseWordsOptimal(" one         "), "one");
            Assert.AreEqual(solution.ReverseWordsOptimal(""), "");
        }
    }
}
