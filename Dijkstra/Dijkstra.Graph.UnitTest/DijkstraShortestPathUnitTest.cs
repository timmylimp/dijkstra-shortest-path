using Dijkstra.Graph.UnitTest.SampleData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Dijkstra.Graph.UnitTest
{
    [TestClass]
    public class DijkstraShortestPathUnitTest
    {
        private SampleGraph _SampleData;

        public DijkstraShortestPathUnitTest()
        {
            _SampleData = SampleGraph.Instance;
        }

        [TestMethod]
        public void FindShortestPath_FromSampleGraphNodeA_SampleGraphShortestPathResultA()
        {
            var actualShortestPathResult = DijkstraShortestPath.FindShortestPath(_SampleData.NodeA, _SampleData.Graph);
            var expectedShortestPathResult = _SampleData.ShortestPathResultA;

            foreach (var n in actualShortestPathResult.DistanceToNodes.Keys)
            {
                var actual = actualShortestPathResult.DistanceToNodes[n];

                var expectedKey = expectedShortestPathResult.DistanceToNodes.Keys.FirstOrDefault(p => p.CompareTo(n) == 0);
                var expected = expectedShortestPathResult.DistanceToNodes[expectedKey];
                Assert.AreEqual(expected, actual);
            }

            foreach (var n in actualShortestPathResult.PreviousNode.Keys)
            {
                var actual = actualShortestPathResult.PreviousNode[n];

                var expectedKey = expectedShortestPathResult.PreviousNode.Keys.FirstOrDefault(p => p.CompareTo(n) == 0);
                var expected = expectedShortestPathResult.PreviousNode[expectedKey];

                if (actual == null)
                    Assert.IsNull(expected);
                else
                    Assert.IsTrue(expected.CompareTo(actual) == 0);
            }
        }

        [TestMethod]
        public void FindShortestPath_FromSampleGraphNodeG_SampleGraphShortestPathResultG()
        {
            var actualShortestPathResult = DijkstraShortestPath.FindShortestPath(_SampleData.NodeG, _SampleData.Graph);
            var expectedShortestPathResult = _SampleData.ShortestPathResultG;

            foreach (var n in actualShortestPathResult.DistanceToNodes.Keys)
            {
                var actual = actualShortestPathResult.DistanceToNodes[n];

                var expectedKey = expectedShortestPathResult.DistanceToNodes.Keys.FirstOrDefault(p => p.CompareTo(n) == 0);
                var expected = expectedShortestPathResult.DistanceToNodes[expectedKey];
                Assert.AreEqual(expected, actual);
            }

            foreach (var n in actualShortestPathResult.PreviousNode.Keys)
            {
                var actual = actualShortestPathResult.PreviousNode[n];

                var expectedKey = expectedShortestPathResult.PreviousNode.Keys.FirstOrDefault(p => p.CompareTo(n) == 0);
                var expected = expectedShortestPathResult.PreviousNode[expectedKey];

                if (actual == null)
                    Assert.IsNull(expected);
                else
                    Assert.IsTrue(expected.CompareTo(actual) == 0);
            }
        }
    }
}
