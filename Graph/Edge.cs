using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeictraGraph
{
    public class Edge
    {
        public Edge(Vertex vertex, int weight)
        {
            ConnectedVertex = vertex;
            EdgeWeight = weight;
        }

        public Vertex ConnectedVertex { get; set; } // Связанная вершина
        public int EdgeWeight { get; set; }
    }
}
