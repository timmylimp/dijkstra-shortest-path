using Dijkstra.Graph.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            return _Edges.Exists(e=>e.Source.CompareTo(edge.Source) == 0 && e.Destination.CompareTo(edge.Destination) == 0);
        }

        public void AddNode(Node node)
        {
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


    }
}
