using ArrayBalancePoint;
using NUnit.Framework;

namespace ArrayBalancePointTest
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void BalancePointTest()
        {
            var solution = new Solution();

            Assert.AreEqual(solution.BalancePoint(new int[] { 2, 7, 4, 5, -3, 8, 9, -1 }),3);
        }
    }
}
