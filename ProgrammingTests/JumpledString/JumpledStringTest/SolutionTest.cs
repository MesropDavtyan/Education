using JumpledString;
using NUnit.Framework;

namespace JumpledStringTest
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void JumbleSentanceTest()
        {
            var solution = new Solution();

            Assert.AreEqual(solution.JumbleSentence("The cat sat on the Ikea mat."),"Eht act ast no eht Aeik amt.");
        }
    }
}
