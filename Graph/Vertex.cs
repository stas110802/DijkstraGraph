using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeictraGraph
{
    public class Vertex
    {
        public Vertex(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Edge> Edges { get; set; } = new();

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public void AddEdge(Vertex vertex, int weight)
        {
            AddEdge(new Edge(vertex, weight));
        }
    }
}
