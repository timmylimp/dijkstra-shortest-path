using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra.Graph
{
    public class MainProgram
    {
        public static void Main()
        {
            var graph = new Graph();

            //graph.GenerateRandomGraph(nodeCount: 6, edgePropabality: 0.5, minDistance: 1, maxDistance: 5);

            var Nodes = new List<Node>();
            Nodes.Add(new Node { Name = "A" });
            Nodes.Add(new Node { Name = "B" });
            Nodes.Add(new Node { Name = "C" });
            Nodes.Add(new Node { Name = "D" });
            Nodes.Add(new Node { Name = "E" });
            Nodes.Add(new Node { Name = "F" });

            var Edges = new List<Edge>();
            Edges.Add(new Edge { Source = Nodes[0], Destination = Nodes[1], Weight = 1 });
            Edges.Add(new Edge { Source = Nodes[0], Destination = Nodes[2], Weight = 2 });
            Edges.Add(new Edge { Source = Nodes[1], Destination = Nodes[2], Weight = 1 });
            Edges.Add(new Edge { Source = Nodes[1], Destination = Nodes[3], Weight = 3 });
            Edges.Add(new Edge { Source = Nodes[1], Destination = Nodes[4], Weight = 2 });
            Edges.Add(new Edge { Source = Nodes[2], Destination = Nodes[3], Weight = 1 });
            Edges.Add(new Edge { Source = Nodes[2], Destination = Nodes[4], Weight = 2 });
            Edges.Add(new Edge { Source = Nodes[3], Destination = Nodes[4], Weight = 4 });
            //Edges.Add(new Edge { Source = Nodes[3], Destination = Nodes[5], Weight = 3 });
            //Edges.Add(new Edge { Source = Nodes[4], Destination = Nodes[5], Weight = 3 });

            foreach (var e in Edges)
            {
                graph.AddEdge(e);
            }

            graph.AddNode(Nodes[5]);

            var result = DijkstraShortestPath.FindShortestPath(graph.Nodes.First(), graph);
            result.PrintResult();
            Console.ReadKey();
        }
    }
}
