using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Graph
{
    public class DijkstraShortestPath
    {
        /// <summary>
        /// Calculate the shortest path with Dijkstra's algorithm.
        /// </summary>
        /// <param name="start">Node to start finding shortest path</param>
        /// <param name="graph">Graph represent nodes and edges linking nodes.</param>
        /// <returns>ShortestPathResult from start node to other nodes in the graph.</returns>
        public static ShortestPathResult FindShortestPath(Node start, Graph graph)
        {
            var distanceToNodes = new Dictionary<Node, int>();
            var previousNode = new Dictionary<Node, Node>();
            var VisitedNodes = new List<Node>();
            var QueueNodes = new SimplePriorityQueue<Node>();

            foreach (var n in graph.Nodes)
            {
                if (n.CompareTo(start) != 0)
                    distanceToNodes[n] = int.MaxValue;
                else
                    distanceToNodes[n] = 0;

                previousNode[n] = null;
                QueueNodes.Enqueue(n, distanceToNodes[n]);
            }

            while (QueueNodes.Count > 0)
            {
                var u = QueueNodes.Dequeue();

                foreach (var e in graph.GetEdgesToNeighbors(u))
                {
                    var v = e.Destination;
                    int alt;
                    try
                    {
                        alt = checked(distanceToNodes[u] + e.Weight);
                    }
                    catch
                    {
                        alt = int.MaxValue;
                    }
                    if (alt < distanceToNodes[v])
                    {
                        distanceToNodes[v] = alt;
                        previousNode[v] = u;
                        QueueNodes.UpdatePriority(v, distanceToNodes[v]);
                    }
                }
            }

            return new ShortestPathResult
            {
                Graph = graph,
                Start = start,
                DistanceToNodes = distanceToNodes,
                PreviousNode = previousNode
            };
        }
    }
}
