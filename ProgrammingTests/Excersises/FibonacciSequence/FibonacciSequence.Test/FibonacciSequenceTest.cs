using FibonacciSequence;
using NUnit.Framework;

namespace FibonacciSequence.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(8, 21)]
        [TestCase(10, 55)]
        public void GenerateFibonaccieNumber_RunWithSpecificParameter_GetValidResult(int number, int expectedResult)
        {
            //Arrenge
            var solution = new Solution();

            //Act
            var result = solution.FibonacciNumber(number);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}