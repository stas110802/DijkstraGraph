using System;

namespace DeictraGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            for (char i = 'A'; i <= 'G'; i++)
            {
                graph.AddVertex($"{i}");
            }

            //добавление ребер
            graph.AddEdge("A", "B", 22);
            graph.AddEdge("A", "C", 33);
            graph.AddEdge("A", "D", 61);
            graph.AddEdge("B", "C", 47);
            graph.AddEdge("B", "E", 93);
            graph.AddEdge("C", "D", 11);
            graph.AddEdge("C", "E", 79);
            graph.AddEdge("C", "F", 63);
            graph.AddEdge("D", "F", 41);
            graph.AddEdge("E", "F", 17);
            graph.AddEdge("E", "G", 58);
            graph.AddEdge("F", "G", 84);

            var dijkstra = new Dijkstra.Dijkstra(graph);

            var path = dijkstra.FindShortestPath("A", "F");
            Console.WriteLine(path);
            Console.ReadLine();
        }
    }
}
