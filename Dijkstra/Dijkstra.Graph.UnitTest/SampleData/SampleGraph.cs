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

        public Node NodeA;
        public Node NodeB;
        public Node NodeC;
        public Node NodeD;
        public Node NodeE;
        public Node NodeF;
        public Node NodeG;
        public Node InvalidNode;

        public Edge EdgeAB;
        public Edge EdgeAC;
        public Edge EdgeBC;
        public Edge EdgeBE;
        public Edge EdgeBD;
        public Edge EdgeCD;
        public Edge EdgeCE;
        public Edge EdgeDE;
        public Edge EdgeDF;
        public Edge EdgeEF;
        public Edge InvalidEdge;

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
            NodeA = new Node { Name = "A" };
            NodeB = new Node { Name = "B" };
            NodeC = new Node { Name = "C" };
            NodeD = new Node { Name = "D" };
            NodeE = new Node { Name = "E" };
            NodeF = new Node { Name = "F" };
            NodeG = new Node { Name = "G" };
            InvalidNode = new Node { Name = "" };

            EdgeAB = new Edge { Source = NodeA, Destination = NodeB, Weight = 1 };
            EdgeAC = new Edge { Source = NodeA, Destination = NodeC, Weight = 2 };
            EdgeBC = new Edge { Source = NodeB, Destination = NodeC, Weight = 1 };
            EdgeBE = new Edge { Source = NodeB, Destination = NodeE, Weight = 2 };
            EdgeBD = new Edge { Source = NodeB, Destination = NodeD, Weight = 3 };
            EdgeCD = new Edge { Source = NodeC, Destination = NodeD, Weight = 1 };
            EdgeCE = new Edge { Source = NodeC, Destination = NodeE, Weight = 2 };
            EdgeDE = new Edge { Source = NodeD, Destination = NodeE, Weight = 4 };
            EdgeDF = new Edge { Source = NodeD, Destination = NodeF, Weight = 3 };
            EdgeEF = new Edge { Source = NodeE, Destination = NodeF, Weight = 3 };
            InvalidEdge = new Edge { Source = NodeA, Destination = NodeB, Weight = -1 };
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
                    { NodeG, 0 }
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
