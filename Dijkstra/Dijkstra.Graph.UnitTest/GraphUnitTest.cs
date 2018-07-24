using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Dijkstra.Graph.UnitTest
{
    [TestClass]
    public class GraphUnitTest
    {
        private readonly Graph graph; 
        private readonly Node nodeA;
        private readonly Node nodeB;
        private readonly Node nodeC;
        private readonly Node nodeD;
        private readonly Node nodeE;
        private readonly Node nodeF;
        private readonly Node invalidNode;

        private readonly Edge edgeAB;
        private readonly Edge edgeAC;
        private readonly Edge edgeBC;
        private readonly Edge edgeBE;
        private readonly Edge edgeBD;
        private readonly Edge edgeCD;
        private readonly Edge edgeCE;
        private readonly Edge edgeDE;
        private readonly Edge edgeDF;
        private readonly Edge edgeEF;
        private readonly Edge invalidEdge;

        public GraphUnitTest()
        {
            graph = new Graph();
            nodeA = new Node { Name = "A" };
            nodeB = new Node { Name = "B" };
            nodeC = new Node { Name = "C" };
            nodeD = new Node { Name = "D" };
            nodeE = new Node { Name = "E" };
            nodeF = new Node { Name = "F" };
            invalidNode = new Node { Name = "" };

            edgeAB = new Edge { Source = nodeA, Destination = nodeB, Weight = 1 };
            edgeAC = new Edge { Source = nodeA, Destination = nodeC, Weight = 2 };
            edgeBC = new Edge { Source = nodeB, Destination = nodeC, Weight = 1 };
            edgeBE = new Edge { Source = nodeB, Destination = nodeE, Weight = 2 };
            edgeBD = new Edge { Source = nodeB, Destination = nodeD, Weight = 3 };
            edgeCD = new Edge { Source = nodeC, Destination = nodeD, Weight = 1 };
            edgeCE = new Edge { Source = nodeC, Destination = nodeE, Weight = 2 };
            edgeDE = new Edge { Source = nodeD, Destination = nodeE, Weight = 4 };
            edgeDF = new Edge { Source = nodeD, Destination = nodeF, Weight = 3 };
            edgeEF = new Edge { Source = nodeE, Destination = nodeF, Weight = 3 };
            invalidEdge = new Edge { Source = nodeA, Destination = nodeB, Weight = -1 };
    }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_NodeCountLessThan0_ArgumentOutOfRangeException()
        {
            graph.GenerateRandomGraph(nodeCount: -1, edgePropabality: 0.5, minDistance: 1, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_EdgePropabilityLessThan0_ArgumentOutOfRangeException()
        {
            graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: -1, minDistance: 1, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_EdgePropabilityMoreThan1_ArgumentOutOfRangeException()
        {
            graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 2, minDistance: 1, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_MinDistanceLessThan0_ArgumentOutOfRangeException()
        {
            graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.5, minDistance: -1, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_MinDistanceMoreThanMaxDistance_ArgumentOutOfRangeException()
        {
            graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.5, minDistance: 10, maxDistance: 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateRandomGraph_MaxDistanceMoreThanMinDistanceAndLessThan0_ArgumentOutOfRangeException()
        {
            graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.5, minDistance: -5, maxDistance: -4);
        }

        [TestMethod]
        public void GenerateRandomGraph_NodeCountIs6EdgePropabilityIs1_CompleteGraphWith6Nodes30Edges()
        {
            graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 1, minDistance: 1, maxDistance: 5);

            Assert.AreEqual(15, graph.Edges.Count());
        }

        [TestMethod]
        public void GenerateRandomGraph_NodeCountIs6EdgePropabilityIs0_GraphWith6Nodes0Edges()
        {
            graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0, minDistance: 1, maxDistance: 5);

            Assert.AreEqual(0, graph.Edges.Count());
        }

        [TestMethod]
        public void GenerateRandomGraph_NodeCountIs6EdgePropabilityIs05_GraphWith6NodesSomeEdges()
        {
            graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.7, minDistance: 1, maxDistance: 5);

            Assert.IsTrue(graph.Edges.Count() > 0);

            foreach (var e in graph.Edges)
            {
                Assert.IsTrue(graph.Nodes.Contains(e.Source));
                Assert.IsTrue(graph.Nodes.Contains(e.Destination));
            }
        }

        [TestMethod]
        public void GenerateRandomGraph_NodeCountIs6EdgePropabilityIs05_AllEdgesConnectToNodes()
        {
            graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.7, minDistance: 1, maxDistance: 5);

            Assert.IsTrue(graph.Edges.Count() > 0);

            foreach (var e in graph.Edges)
            {
                Assert.IsTrue(graph.Nodes.Contains(e.Source));
                Assert.IsTrue(graph.Nodes.Contains(e.Destination));
            }
        }

        [TestMethod]
        public void AddNode_Null_AddNothing()
        {
            graph.AddNode(null);
            Assert.AreEqual(0, graph.Nodes.Count());
        }

        [TestMethod]
        public void AddNode_DuplicateNode_AddOnlyOne()
        {
            graph.AddNode(nodeA);
            graph.AddNode(nodeA);
            graph.AddNode(nodeA);
            Assert.AreEqual(1, graph.Nodes.Count());
        }

        [TestMethod]
        public void AddNode_InvalidNode_AddNothing()
        {
            graph.AddNode(invalidNode);
            Assert.AreEqual(0, graph.Nodes.Count());
        }

        [TestMethod]
        public void AddNode_3DifferrentNodes_Have3Nodes()
        {
            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
            Assert.AreEqual(3, graph.Nodes.Count());
        }

        [TestMethod]
        public void AddEdge_Null_AddNothing()
        {
            graph.AddEdge(null);
            Assert.AreEqual(0, graph.Nodes.Count());
        }

        [TestMethod]
        public void AddEdge_InvalidEdge_AddNothing()
        {
            graph.AddEdge(invalidEdge);
            Assert.AreEqual(0, graph.Nodes.Count());
        }
        
        [TestMethod]
        public void AddNode_DuplicateEdge_AddOnlyOneEdgeWith2Nodes()
        {
            graph.AddEdge(edgeAB);
            graph.AddEdge(edgeAB);
            graph.AddEdge(edgeAB);
            Assert.AreEqual(1, graph.Edges.Count());
            Assert.AreEqual(2, graph.Nodes.Count());
        }

        [TestMethod]
        public void AddNode_3EdgesConnect4Node_Have3Edges4Nodes()
        {
            graph.AddEdge(edgeAB);
            graph.AddEdge(edgeBC);
            graph.AddEdge(edgeBD);
            Assert.AreEqual(3, graph.Edges.Count());
            Assert.AreEqual(4, graph.Nodes.Count());
        }

        [TestMethod]
        public void GetEdgesToNeighbors_NodeBHave3Degree_3Edges()
        {
            graph.AddEdge(edgeAB);
            graph.AddEdge(edgeBC);
            graph.AddEdge(edgeBD);

            var edges = graph.GetEdgesToNeighbors(nodeB);
            Assert.AreEqual(3, edges.Count());
        }

        [TestMethod]
        public void GetEdgesToNeighbors_NodeBHave3Degree_AllEdgeSourcesMustBeNodeB()
        {
            graph.AddEdge(edgeAB);
            graph.AddEdge(edgeBC);
            graph.AddEdge(edgeBD);

            foreach (var e in graph.GetEdgesToNeighbors(nodeB))
            {
                Assert.AreEqual(nodeB, e.Source);
            }
        }

        [TestMethod]
        public void GetEdgesToNeighbors_NodeBHave1Degree_1Edges()
        {
            graph.AddEdge(edgeAB);
            graph.AddEdge(edgeBC);
            graph.AddEdge(edgeBD);

            var edges = graph.GetEdgesToNeighbors(nodeA);
            Assert.AreEqual(1, edges.Count());
        }

        [TestMethod]
        public void GetEdgesToNeighbors_NodeAHave1Degree_AllEdgeSourcesMustBeNodeA()
        {
            graph.AddEdge(edgeAB);
            graph.AddEdge(edgeBC);
            graph.AddEdge(edgeBD);

            foreach (var e in graph.GetEdgesToNeighbors(nodeA))
            {
                Assert.AreEqual(nodeA, e.Source);
            }
        }
    }
}
