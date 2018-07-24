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
                Console.WriteLine(ShowPathTo(n));
            }
            Console.WriteLine("-----------------------------------");
        }

        /// <summary>
        /// Path from Start node to the input target.
        /// </summary>
        /// <param name="target"></param>
        /// <returns>Sequence of nodes to target with distance.</returns>
        public string ShowPathTo(Node target)
        {
            Stack<Node> Path = new Stack<Node>();
            var node = target;

            while(node != null)
            {
                Path.Push(node);
                node = PreviousNode[node];
            }

            if (Path.Peek() != Start)
                return String.Format("There's no way to {0}.", target);
            else
            {
                StringBuilder path = new StringBuilder();
                foreach (var n in Path)
                {
                    path.AppendFormat("{0} - ", n);
                }
                path.Remove(path.Length - 2, 2);
                path.AppendFormat("= {0}", DistanceToNodes[target]);
                return path.ToString();
            }
        }
    }
}
