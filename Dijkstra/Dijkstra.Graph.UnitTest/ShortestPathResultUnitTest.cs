using Dijkstra.Graph.UnitTest.SampleData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dijkstra.Graph.UnitTest
{
    [TestClass]
    public class ShortestPathResultUnitTest
    {
        private SampleGraph _SampleData;

        public ShortestPathResultUnitTest()
        {
            _SampleData = SampleGraph.Instance;
        }

        [TestMethod]
        public void ShowPathTo_NoConnectionFromNodeAToNodeG_ThereIsNoWayToG()
        {
            var path = _SampleData.ShortestPathResultA.ShowPathTo(_SampleData.NodeG);

            Assert.AreEqual("There's no way to G.", path);
        }

        [TestMethod]
        public void ShowPathTo_ConnectionFromNodeAToNodeB_AB1()
        {
            var path = _SampleData.ShortestPathResultA.ShowPathTo(_SampleData.NodeB);

            Assert.AreEqual("A - B = 1", path);
        }

        [TestMethod]
        public void ShowPathTo_ConnectionFromNodeAToNodeC_AC2()
        {
            var path = _SampleData.ShortestPathResultA.ShowPathTo(_SampleData.NodeC);

            Assert.AreEqual("A - C = 2", path);
        }

        [TestMethod]
        public void ShowPathTo_ConnectionFromNodeAToNodeD_ACD3()
        {
            var path = _SampleData.ShortestPathResultA.ShowPathTo(_SampleData.NodeD);

            Assert.AreEqual("A - C - D = 3", path);
        }

        [TestMethod]
        public void ShowPathTo_ConnectionFromNodeAToNodeE_ABE3()
        {
            var path = _SampleData.ShortestPathResultA.ShowPathTo(_SampleData.NodeE);

            Assert.AreEqual("A - B - E = 3", path);
        }

        [TestMethod]
        public void ShowPathTo_ConnectionFromNodeAToNodeF_ACDF6()
        {
            var path = _SampleData.ShortestPathResultA.ShowPathTo(_SampleData.NodeF);

            Assert.AreEqual("A - C - D - F = 6", path);
        }
    }
}
