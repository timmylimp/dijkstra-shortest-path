using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Graph
{
    public class ShortestPathResult
    {
        public Graph Graph { get; set; }
        public Node Start { get; set; }
        public Dictionary<Node, int> DistanceToNodes { get; set; }
        public Dictionary<Node, Node> PreviousNode { get; set; }

        public void PrintResult()
        {
            Graph.PrintGraph();
            Console.WriteLine("[Start]");
            Console.WriteLine(Start);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("[Paths]");
            foreach (var n in DistanceToNodes.Keys)
            {
                PrintPathTo(n);
            }
            Console.WriteLine("-----------------------------------");
        }

        public void PrintPathTo(Node target)
        {
            Stack<Node> Path = new Stack<Node>();
            var node = target;
            while(node != null)
            {
                Path.Push(node);
                node = PreviousNode[node];
            }

            if (Path.Peek() != Start)
                Console.WriteLine("There's no way to {0}.", target);
            else
            {
                foreach (var n in Path)
                {
                    Console.Write(" >> {0} ", n);
                }
                Console.WriteLine(" = {0}", DistanceToNodes[target]);
            }
        }
    }
}
