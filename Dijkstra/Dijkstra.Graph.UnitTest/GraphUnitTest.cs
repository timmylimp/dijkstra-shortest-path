using Dijkstra.Graph.UnitTest.SampleData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace Dijkstra.Graph.UnitTest
{
    [TestClass]
    public class GraphUnitTest
    {
        private Graph _Graph;
        private SampleGraph _SampleData;

        public GraphUnitTest()
        {
            _Graph = new Graph();
            _SampleData = SampleGraph.Instance;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_NodeCountLessThan0_ArgumentOutOfRangeException()
        {
            _Graph.GenerateRandomGraph(nodeCount: -1, edgePropabality: 0.5, minDistance: 1, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_EdgePropabilityLessThan0_ArgumentOutOfRangeException()
        {
            _Graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: -1, minDistance: 1, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_EdgePropabilityMoreThan1_ArgumentOutOfRangeException()
        {
            _Graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 2, minDistance: 1, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_MinDistanceLessThan0_ArgumentOutOfRangeException()
        {
            _Graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.5, minDistance: -1, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_MinDistanceMoreThanMaxDistance_ArgumentOutOfRangeException()
        {
            _Graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.5, minDistance: 10, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_MaxDistanceMoreThanMinDistanceAndLessThan0_ArgumentOutOfRangeException()
        {
            _Graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.5, minDistance: -5, maxDistance: -4);
        }

        [TestMethod]
        public void GenerateRandomGraph_NodeCountIs6EdgePropabilityIs1_CompleteGraphWith6Nodes30Edges()
        {
            _Graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 1, minDistance: 1, maxDistance: 5);

            Assert.AreEqual(15, _Graph.Edges.Count());
        }

        [TestMethod]
        public void GenerateRandomGraph_NodeCountIs6EdgePropabilityIs0_GraphWith6Nodes0Edges()
        {
            _Graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0, minDistance: 1, maxDistance: 5);

            Assert.AreEqual(0, _Graph.Edges.Count());
        }

        [TestMethod]
        public void GenerateRandomGraph_NodeCountIs6EdgePropabilityIs05_GraphWith6NodesSomeEdges()
        {
            _Graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.7, minDistance: 1, maxDistance: 5);

            Assert.IsTrue(_Graph.Edges.Count() > 0);

            foreach (var e in _Graph.Edges)
            {
                Assert.IsTrue(_Graph.Nodes.Contains(e.Source));
                Assert.IsTrue(_Graph.Nodes.Contains(e.Destination));
            }
        }

        [TestMethod]
        public void GenerateRandomGraph_NodeCountIs6EdgePropabilityIs05_AllEdgesConnectToNodes()
        {
            _Graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.7, minDistance: 1, maxDistance: 5);

            Assert.IsTrue(_Graph.Edges.Count() > 0);

            foreach (var e in _Graph.Edges)
            {
                Assert.IsTrue(_Graph.Nodes.Contains(e.Source));
                Assert.IsTrue(_Graph.Nodes.Contains(e.Destination));
            }
        }

        [TestMethod]
        public void AddNode_Null_AddNothing()
        {
            _Graph.AddNode(null);
            Assert.AreEqual(0, _Graph.Nodes.Count());
        }

        [TestMethod]
        public void AddNode_DuplicateNode_AddOnlyOne()
        {
            _Graph.AddNode(_SampleData.NodeA);
            _Graph.AddNode(_SampleData.NodeA);
            _Graph.AddNode(_SampleData.NodeA);
            Assert.AreEqual(1, _Graph.Nodes.Count());
        }

        [TestMethod]
        public void AddNode_InvalidNode_AddNothing()
        {
            _Graph.AddNode(_SampleData.InvalidNode);
            Assert.AreEqual(0, _Graph.Nodes.Count());
        }

        [TestMethod]
        public void AddNode_3DifferrentNodes_Have3Nodes()
        {
            _Graph.AddNode(_SampleData.NodeA);
            _Graph.AddNode(_SampleData.NodeB);
            _Graph.AddNode(_SampleData.NodeC);
            Assert.AreEqual(3, _Graph.Nodes.Count());
        }

        [TestMethod]
        public void AddEdge_Null_AddNothing()
        {
            _Graph.AddEdge(null);
            Assert.AreEqual(0, _Graph.Nodes.Count());
        }

        [TestMethod]
        public void AddEdge_InvalidEdge_AddNothing()
        {
            _Graph.AddEdge(_SampleData.InvalidEdge);
            Assert.AreEqual(0, _Graph.Nodes.Count());
        }
        
        [TestMethod]
        public void AddNode_DuplicateEdge_AddOnlyOneEdgeWith2Nodes()
        {
            _Graph.AddEdge(_SampleData.EdgeAB);
            _Graph.AddEdge(_SampleData.EdgeAB);
            _Graph.AddEdge(_SampleData.EdgeAB);
            Assert.AreEqual(1, _Graph.Edges.Count());
            Assert.AreEqual(2, _Graph.Nodes.Count());
        }

        [TestMethod]
        public void AddNode_3EdgesConnect4Node_Have3Edges4Nodes()
        {
            _Graph.AddEdge(_SampleData.EdgeAB);
            _Graph.AddEdge(_SampleData.EdgeBC);
            _Graph.AddEdge(_SampleData.EdgeBD);
            Assert.AreEqual(3, _Graph.Edges.Count());
            Assert.AreEqual(4, _Graph.Nodes.Count());
        }

        [TestMethod]
        public void GetEdgesToNeighbors_NodeBHave3Degree_3Edges()
        {
            _Graph.AddEdge(_SampleData.EdgeAB);
            _Graph.AddEdge(_SampleData.EdgeBC);
            _Graph.AddEdge(_SampleData.EdgeBD);

            var edges = _Graph.GetEdgesToNeighbors(_SampleData.NodeB);
            Assert.AreEqual(3, edges.Count());
        }

        [TestMethod]
        public void GetEdgesToNeighbors_NodeBHave3Degree_AllEdgeSourcesMustBeNodeB()
        {
            _Graph.AddEdge(_SampleData.EdgeAB);
            _Graph.AddEdge(_SampleData.EdgeBC);
            _Graph.AddEdge(_SampleData.EdgeBD);

            var edges = _Graph.GetEdgesToNeighbors(_SampleData.NodeB);
            foreach (var e in _Graph.GetEdgesToNeighbors(_SampleData.NodeB))
            {
                Assert.IsTrue(_SampleData.NodeB.CompareTo(e.Source) == 0);
            }
        }

        [TestMethod]
        public void GetEdgesToNeighbors_NodeBHave1Degree_1Edges()
        {
            _Graph.AddEdge(_SampleData.EdgeAB);
            _Graph.AddEdge(_SampleData.EdgeBC);
            _Graph.AddEdge(_SampleData.EdgeBD);

            var edges = _Graph.GetEdgesToNeighbors(_SampleData.NodeA);
            Assert.AreEqual(1, edges.Count());
        }

        [TestMethod]
        public void GetEdgesToNeighbors_NodeAHave1Degree_AllEdgeSourcesMustBeNodeA()
        {
            _Graph.AddEdge(_SampleData.EdgeAB);
            _Graph.AddEdge(_SampleData.EdgeBC);
            _Graph.AddEdge(_SampleData.EdgeBD);

            foreach (var e in _Graph.GetEdgesToNeighbors(_SampleData.NodeA))
            {
                Assert.IsTrue(_SampleData.NodeA.CompareTo(e.Source) == 0);
            }
        }
    }
}
