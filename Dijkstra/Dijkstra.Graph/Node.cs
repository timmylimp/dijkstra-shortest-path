using System;
using System.ComponentModel.DataAnnotations;

namespace Dijkstra.Graph
{
    public class Node:IComparable<Node>
    {
        [Required]
        public string Name { get; set; }

        public int CompareTo(Node other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
