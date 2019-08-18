using NUnit.Framework;
using SGApp;
using System.Linq;

namespace SGAppTest
{
    public class CombinationCalculatorTests
    {
        Combination[] conbinations;
        Combination[] simpleConbinations;

        private readonly int[] possibleItemsValues = new int[] { 1, 5, 10, 25 };
        private readonly int targetValue = 1000;

        [OneTimeSetUp]
        public void SetupTests()
        {
            CombinationCalculator cc = new CombinationCalculator(targetValue, possibleItemsValues);
            conbinations = cc.GetCombinations();
            SimpleCombinationCalculator scc = new SimpleCombinationCalculator();
            simpleConbinations = scc.GetCombinations();
        }

        [Test]
        public void TestEquality()
        {
            // Same result for both implementations
            Assert.That(conbinations.Length, Is.EqualTo(simpleConbinations.Length));
            Assert.That(conbinations.Where(x => !simpleConbinations.Contains(x)).Count, Is.EqualTo(0));
        }

        [Test]
        public void TestNoDuplicate()
        {
            // No duplicate
            Assert.That(conbinations.Distinct().Count, Is.EqualTo(conbinations.Length));
            Assert.That(simpleConbinations.Distinct().Count, Is.EqualTo(simpleConbinations.Length));
        }
    }
}