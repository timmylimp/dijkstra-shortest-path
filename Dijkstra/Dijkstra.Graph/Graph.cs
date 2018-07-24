using Dijkstra.Graph.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dijkstra.Graph
{
    public class Graph
    {
        private readonly List<Node> _Nodes;
        public IEnumerable<Node> Nodes
        {
            get
            {
                return (IEnumerable<Node>)_Nodes;
            }
        }

        private readonly List<Edge> _Edges;
        public IEnumerable<Edge> Edges
        {
            get
            {
                return (IEnumerable<Edge>)_Edges;
            }
        }


        public Graph()
        {
            _Nodes = new List<Node>();
            _Edges = new List<Edge>();
        }

        public bool NodeExists(Node node)
        {
            return _Nodes.Exists(n => n.CompareTo(node) == 0);
        }

        public bool EdgeExists(Edge edge)
        {
            return _Edges.Exists(e =>
                {
                    return (e.Source.CompareTo(edge.Source) == 0 && e.Destination.CompareTo(edge.Destination) == 0) ||
                           (e.Source.CompareTo(edge.Destination) == 0 && e.Destination.CompareTo(edge.Source) == 0);
                }
            );
        }

        public void AddNode(Node node)
        {
            if (!node.TryValidate(out List<ValidationResult> validationResult))
                throw new ArgumentException(validationResult.ToFlatternMessage());
            if (node != null && !NodeExists(node))
                _Nodes.Add(node);
        }

        public void AddEdge(Edge edge)
        {
            if (edge == null || EdgeExists(edge))
                return;

            if (!edge.TryValidate(out List<ValidationResult> validationResult))
                throw new ArgumentException(validationResult.ToFlatternMessage());

            AddNode(edge.Source);
            AddNode(edge.Destination);
            _Edges.Add(edge);
        }
        public void AddEdge(Node source, Node destination, int weight)
        {
            AddEdge(
                new Edge
                {
                    Source = source,
                    Destination = destination,
                    Weight = weight
                }
            );

        }

        public IEnumerable<Edge> GetEdgesToNeighbors(Node node)
        {
            foreach (var e in _Edges.Where(e => e.Source.CompareTo(node) == 0))
            {
                yield return e;
            }
            foreach (var e in _Edges.Where(e => e.Destination.CompareTo(node) == 0))
            {
                e.Destination = e.Source;
                e.Source = node;
                yield return e;
            }
        }

        public void GenerateRandomGraph(int nodeCount = 6,
            double edgePropabality = 0.5,
            int minDistance = 1,
            int maxDistance = 1000)
        {
            if (nodeCount <= 0)
                throw new ArgumentOutOfRangeException("nodeCount should be greater than 0.");

            _Nodes.Clear();
            _Edges.Clear();
            GenerateNodes(nodeCount);
            GenerateEdges(edgePropabality, minDistance, maxDistance);
        }

        public void PrintGraph()
        {
            Console.WriteLine("[Graph]: ");
            Console.WriteLine("<<< Nodes >>> ");
            foreach (var node in Nodes)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("<<< Edges >>> ");
            foreach (var edge in Edges)
            {
                Console.WriteLine(edge);
            }
            Console.WriteLine("-----------------------------------");
        }

        private void GenerateNodes(int nodeCount)
        {
            while (_Nodes.Count < nodeCount)
            {
                AddNode(new Node { Name = RandomUtils.NextPlaceName() });
            }
        }

        private void GenerateEdges(double edgePropabality,
            int minDistance,
            int maxDistance)
        {
            for (int i = 0; i < _Nodes.Count; i++)
            {
                for (int j = i + 1; j < _Nodes.Count; j++)
                {
                    if (RandomUtils.NextAppearance(edgePropabality))
                        continue;

                    var edge = new Edge
                    {
                        Source = _Nodes[i],
                        Destination = _Nodes[j],
                        Weight = RandomUtils.NextDistance(minDistance, maxDistance)
                    };
                    _Edges.Add(edge);
                }
            }
        }
    }
}
