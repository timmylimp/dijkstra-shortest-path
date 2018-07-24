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

        [Range(0, int.MaxValue, ErrorMessage = "The field Weight must be greater or equal 0.")]
        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return Weight - other.Weight;
        }

        public override string ToString()
        {
            return string.Format("{0} <-> {1} = {2}", Source.Name, Destination.Name, Weight);
        }
    }
}
