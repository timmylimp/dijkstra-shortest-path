using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Graph.UnitTest.SampleData
{
    public class SampleGraph
    {
        public Graph Graph;
        public ShortestPathResult ShortestPathResultA;
        public ShortestPathResult ShortestPathResultG;

        public Node NodeA = new Node { Name = "A" };
        public Node NodeB = new Node { Name = "B" };
        public Node NodeC = new Node { Name = "C" };
        public Node NodeD = new Node { Name = "D" };
        public Node NodeE = new Node { Name = "E" };
        public Node NodeF = new Node { Name = "F" };
        public Node NodeG = new Node { Name = "G" };
        public Node InvalidNode = new Node { Name = "" };

        public Edge EdgeAB = new Edge { Source = SampleNodes.NodeA, Destination = SampleNodes.NodeB, Weight = 1 };
        public Edge EdgeAC = new Edge { Source = SampleNodes.NodeA, Destination = SampleNodes.NodeC, Weight = 2 };
        public Edge EdgeBC = new Edge { Source = SampleNodes.NodeB, Destination = SampleNodes.NodeC, Weight = 1 };
        public Edge EdgeBE = new Edge { Source = SampleNodes.NodeB, Destination = SampleNodes.NodeE, Weight = 2 };
        public Edge EdgeBD = new Edge { Source = SampleNodes.NodeB, Destination = SampleNodes.NodeD, Weight = 3 };
        public Edge EdgeCD = new Edge { Source = SampleNodes.NodeC, Destination = SampleNodes.NodeD, Weight = 1 };
        public Edge EdgeCE = new Edge { Source = SampleNodes.NodeC, Destination = SampleNodes.NodeE, Weight = 2 };
        public Edge EdgeDE = new Edge { Source = SampleNodes.NodeD, Destination = SampleNodes.NodeE, Weight = 4 };
        public Edge EdgeDF = new Edge { Source = SampleNodes.NodeD, Destination = SampleNodes.NodeF, Weight = 3 };
        public Edge EdgeEF = new Edge { Source = SampleNodes.NodeE, Destination = SampleNodes.NodeF, Weight = 3 };
        public Edge InvalidEdge = new Edge { Source = SampleNodes.NodeA, Destination = SampleNodes.NodeB, Weight = -1 };

        private static SampleGraph _Instance;
        public static SampleGraph Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SampleGraph();
                return _Instance;
            }
        }

        private SampleGraph()
        {
            Graph = new Graph();

            Graph.AddNode(NodeA);
            Graph.AddNode(NodeB);
            Graph.AddNode(NodeC);
            Graph.AddNode(NodeD);
            Graph.AddNode(NodeE);
            Graph.AddNode(NodeF);
            Graph.AddNode(NodeG);

            Graph.AddEdge(EdgeAB);
            Graph.AddEdge(EdgeAC);
            Graph.AddEdge(EdgeBC);
            Graph.AddEdge(EdgeBE);
            Graph.AddEdge(EdgeBD);
            Graph.AddEdge(EdgeCD);
            Graph.AddEdge(EdgeCE);
            Graph.AddEdge(EdgeDE);
            Graph.AddEdge(EdgeDF);
            Graph.AddEdge(EdgeEF);

            ShortestPathResultA = new ShortestPathResult
            {
                Graph = Graph,
                Start = NodeA,
                DistanceToNodes = new Dictionary<Node, int>
                {
                    { NodeA, 0 },
                    { NodeB, 1 },
                    { NodeC, 2 },
                    { NodeD, 3 },
                    { NodeE, 3 },
                    { NodeF, 6 },
                    { NodeG, int.MaxValue }
                },
                PreviousNode = new Dictionary<Node, Node>
                {
                    { NodeA, null },
                    { NodeB, NodeA },
                    { NodeC, NodeA },
                    { NodeD, NodeC },
                    { NodeE, NodeB },
                    { NodeF, NodeD },
                    { NodeG, null}
                }
            };

            ShortestPathResultG = new ShortestPathResult
            {
                Graph = Graph,
                Start = NodeG,
                DistanceToNodes = new Dictionary<Node, int>
                {
                    { NodeA, int.MaxValue },
                    { NodeB, int.MaxValue },
                    { NodeC, int.MaxValue },
                    { NodeD, int.MaxValue },
                    { NodeE, int.MaxValue },
                    { NodeF, int.MaxValue },
                    { NodeG, int.MaxValue }
                },
                PreviousNode = new Dictionary<Node, Node>
                {
                    { NodeA, null },
                    { NodeB, null },
                    { NodeC, null },
                    { NodeD, null },
                    { NodeE, null },
                    { NodeF, null },
                    { NodeG, null}
                }
            };
        }
    }
}
