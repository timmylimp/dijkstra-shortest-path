using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Graph
{
    public class Class1
    {
        public static void Main()
        {
            var graph = new Graph();

            graph.GenerateRandomGraph();
            Console.WriteLine("Nodes: ");
            foreach (var node in graph.Nodes)
            {
                Console.WriteLine(node.Name);
            }
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Edges: ");
            foreach (var edge in graph.Edges)
            {
                Console.WriteLine("{0} <-> {1} = {2}", edge.Source.Name, edge.Destination.Name, edge.Weight);
            }
            Console.WriteLine("-----------------------------------");


        }
    }
}
