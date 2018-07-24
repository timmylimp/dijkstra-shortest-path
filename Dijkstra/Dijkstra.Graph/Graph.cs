using Dijkstra.Graph.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dijkstra.Graph
{
    /// <summary>
    /// Collection of Nodes and Edges. This represent undirected graph.
    /// </summary>
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

        /// <summary>
        /// Check if input node is in graph.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>True if graph have node Name exactly matched to input node. Otherwise false.</returns>
        public bool NodeExists(Node node)
        {
            return _Nodes.Exists(n => n.CompareTo(node) == 0);
        }

        /// <summary>
        /// Check if input edge is in graph
        /// </summary>
        /// <param name="edge"></param>
        /// <returns>True if graph have Source or Destination as same as input edge. Otherwise false. The Source snd Destination can swaped because this is undirected graph.</returns>
        public bool EdgeExists(Edge edge)
        {
            return _Edges.Exists(e =>
                {
                    return (e.Source.CompareTo(edge.Source) == 0 && e.Destination.CompareTo(edge.Destination) == 0) ||
                           (e.Source.CompareTo(edge.Destination) == 0 && e.Destination.CompareTo(edge.Source) == 0);
                }
            );
        }

        /// <summary>
        /// Add a valid node into graph.
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(Node node)
        {
            if (node == null || !node.TryValidate(out List<ValidationResult> validationResult) || NodeExists(node))
                return;

            _Nodes.Add(node);
        }

        /// <summary>
        /// Add a valid edge into graph.
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(Edge edge)
        {
            if (edge == null || EdgeExists(edge) || !edge.TryValidate(out List<ValidationResult> validationResult))
                return;

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

        /// <summary>
        /// Get all edges linking to input node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Edges which connect to input node and swap input node to Source of edge.</returns>
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

        /// <summary>
        /// Generate dummy graph randomly.
        /// </summary>
        /// <param name="nodeCount">Number of nodes in the graph. Must be greater than 0.</param>
        /// <param name="edgePropabality">Probability of the edge to be generate. The more number is more edges. This must be double from 0 to 1.</param>
        /// <param name="minDistance">The smallest edge weight in graph to be randomed. Must be greater than 0.</param>
        /// <param name="maxDistance">The largest edge weight in graph to be randomed. Mustbe greater or equal minDistance.</param>
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

        /// <summary>
        /// Print graph to console.
        /// </summary>
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

        /// <summary>
        /// Generate node with random name.
        /// </summary>
        /// <param name="nodeCount">Number of nodes to be generated. Must be greater than 1.</param>
        private void GenerateNodes(int nodeCount)
        {
            while (_Nodes.Count < nodeCount)
            {
                AddNode(new Node { Name = RandomUtils.NextPlaceName() });
            }
        }

        /// <summary>
        /// Generate edges randomly.
        /// </summary>
        /// <param name="edgePropabality">Probability of the edge to be generate. The more number is more edges. This must be double from 0 to 1.</param>
        /// <param name="minDistance">The smallest edge weight in graph to be randomed. Must be greater than 0.</param>
        /// <param name="maxDistance">The largest edge weight in graph to be randomed. Mustbe greater or equal minDistance.</param>
        private void GenerateEdges(double edgePropabality,
            int minDistance,
            int maxDistance)
        {
            for (int i = 0; i < _Nodes.Count; i++)
            {
                for (int j = i + 1; j < _Nodes.Count; j++)
                {
                    if (!RandomUtils.NextAppearance(edgePropabality))
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
