using Dijkstra.Graph.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dijkstra.Graph.UnitTest
{
    [TestClass]
    public class RandomUtilsUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextDistance_MinDistanceLessThanZero_ThrowArgumentOutOfRangeException()
        {
            var rand = RandomUtils.NextDistance(-1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextDistance_MinDistanceIsZero_ThrowArgumentOutOfRangeException()
        {
            var rand = RandomUtils.NextDistance(0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextDistance_MaxDistanceLessThanZero_ThrowArgumentOutOfRangeException()
        {
            var rand = RandomUtils.NextDistance(1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextDistance_MaxDistanceIsZero_ThrowArgumentOutOfRangeException()
        {
            var rand = RandomUtils.NextDistance(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextDistance_MaxDistanceLessThanMinDistance_ThrowArgumentOutOfRangeException()
        {
            var rand = RandomUtils.NextDistance(3, 1);
        }

        [TestMethod]
        public void NextDistance_MaxDistanceEqualsMinDistance_ExactValue()
        {
            var rand = RandomUtils.NextDistance(2, 2);
            Assert.AreEqual(2, rand);

            rand = RandomUtils.NextDistance(11, 11);
            Assert.AreEqual(11, rand);

            rand = RandomUtils.NextDistance(123, 123);
            Assert.AreEqual(123, rand);
        }

        [TestMethod]
        public void NextDistance_MaxDistanceMoreThanMinDistance_BetweenMinAndMax()
        {
            var rand = RandomUtils.NextDistance(2, 3);
            Assert.IsTrue(rand >= 2 && rand <= 3);

            rand = RandomUtils.NextDistance(100, 200);
            Assert.IsTrue(rand >= 100 && rand <= 200);

            rand = RandomUtils.NextDistance(1, 1000);
            Assert.IsTrue(rand >= 1 && rand <= 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextAppearance_PercentageLessThanZero_ThrowArgumentOutOfRangeException()
        {
            var rand = RandomUtils.NextAppearance(-0.1);
        }

        [TestMethod]
        public void NextAppearance_PercentageIsZero_False()
        {
            var rand = RandomUtils.NextAppearance(0);
            Assert.IsFalse(rand);
        }

        [TestMethod]
        public void NextAppearance_PercentageIsOne_True()
        {
            var rand = RandomUtils.NextAppearance(1);
            Assert.IsTrue(rand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NextAppearance_PercentageGreaterThanOne_ThrowArgumentOutOfRangeException()
        {
            var rand = RandomUtils.NextAppearance(5);
        }

        [TestMethod]
        public void NextAppearance_PercentageBetween0And1_NotNull()
        {
            var rand = RandomUtils.NextAppearance(0.5);
            Assert.IsNotNull(rand);
        }

        [TestMethod]
        public void NextPlace_Normal_NotNullString()
        {
            var rand = RandomUtils.NextPlaceName();
            Assert.IsNotNull(rand);
            Assert.IsTrue(rand.Length > 0);
        }
    }
}
