using System;
using System.ComponentModel.DataAnnotations;

namespace Dijkstra.Graph
{
    /// <summary>
    /// Node in graph.
    /// </summary>
    public class Node:IComparable<Node>
    {
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Compare node name to other node.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Negative integer if Name is less than other Name. 0 if Name equals to other name. Otherwise positive integer.</returns>
        public int CompareTo(Node other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
