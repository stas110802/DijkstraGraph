using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeictraGraph.Dijkstra
{
    public class VertexInfo
    {
        public VertexInfo(Vertex vertex)
        {
            Vertex = vertex;
            IsUnvisited = true;
            SumOfWeightEdges = int.MaxValue;
            PreviousVertex = null;
        }

        public bool IsUnvisited { get; set; } //
        public Vertex Vertex { get; set; }
        public Vertex PreviousVertex { get; set; } //
        public int SumOfWeightEdges { get; set; }
    }
}
