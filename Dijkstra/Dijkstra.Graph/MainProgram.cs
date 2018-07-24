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

            var Nodes = new List<Node>
            {
                new Node { Name = "A" },
                new Node { Name = "B" },
                new Node { Name = "C" },
                new Node { Name = "D" },
                new Node { Name = "E" },
                new Node { Name = "F" }
            };

            foreach (var n in Nodes)
            {
                graph.AddNode(n);
            }

            var Edges = new List<Edge>
            {
                new Edge { Source = Nodes[0], Destination = Nodes[1], Weight = 1 },
                new Edge { Source = Nodes[0], Destination = Nodes[2], Weight = 2 },
                new Edge { Source = Nodes[1], Destination = Nodes[2], Weight = 1 },
                new Edge { Source = Nodes[1], Destination = Nodes[3], Weight = 3 },
                new Edge { Source = Nodes[1], Destination = Nodes[4], Weight = 2 },
                new Edge { Source = Nodes[2], Destination = Nodes[3], Weight = 1 },
                new Edge { Source = Nodes[2], Destination = Nodes[4], Weight = 2 },
                new Edge { Source = Nodes[3], Destination = Nodes[4], Weight = 4 }

                //new Edge { Source = Nodes[3], Destination = Nodes[5], Weight = 3 },
                //new Edge { Source = Nodes[4], Destination = Nodes[5], Weight = 3 },
            };

            foreach (var e in Edges)
            {
                graph.AddEdge(e);
            }

            var result = DijkstraShortestPath.FindShortestPath(graph.Nodes.First(), graph);
            result.PrintResult();
            Console.ReadKey();
        }
    }
}
