using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeictraGraph
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; } 
        = new(); // Список вершин графа

        public void AddVertex(string name)
        {
            Vertices.Add(new Vertex(name));
        }

        public void AddEdge(string from, string to, int weight)
        {
            var firstVertex = FindVertex(from);
            var secondVertex = FindVertex(to);

            if(firstVertex != null && secondVertex != null)
            {
                firstVertex.AddEdge(secondVertex, weight);
                secondVertex.AddEdge(firstVertex, weight);
            }
        }

        public Vertex FindVertex(string name)
        {
            foreach (var item in Vertices)
            {
                if(item.Name == name)
                {
                    return item;
                }
            }

            return null;
        }

    }
}
