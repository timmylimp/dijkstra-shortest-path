using System;
using System.ComponentModel.DataAnnotations;

namespace Dijkstra.Graph
{
    public class Edge:IComparable<Edge>
    {
        [Required]
        public Node Source { get; set; }

        [Required]
        public Node Destination { get; set; }

        [Range(0, int.MaxValue)]
        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return Weight - other.Weight;
        }
    }
}
