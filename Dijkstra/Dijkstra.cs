using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeictraGraph.Dijkstra
{
    public class Dijkstra
    {
        public Dijkstra(Graph graph)
        {
            _graph = graph;
        }

        private Graph _graph;
        private List<VertexInfo> _listOfVertexInfo = new();

        public void InitVertexInformation()
        {
            foreach (var item in _graph.Vertices)
            {
                _listOfVertexInfo.Add(new VertexInfo(item));
            }
        }

        public VertexInfo GetVertexInfo(Vertex vertex)
        {
            foreach (var item in _listOfVertexInfo)
            {
                if(item.Vertex == vertex)
                {
                    return item;
                }
            }

            return null;
        }

        public VertexInfo FindUnvisitedVertexWithMinSum()
        {
            var minValue = int.MaxValue;
            VertexInfo minVertexInfo = null;

            foreach (var item in _listOfVertexInfo)
            {
                if (item.IsUnvisited && item.SumOfWeightEdges < minValue)
                {
                    minVertexInfo = item;
                    minValue = item.SumOfWeightEdges;
                }
            }

            return minVertexInfo;
        }

        public string FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(_graph.FindVertex(startName), _graph.FindVertex(finishName));
        }

        public int GetPathSum(string path)
        {
            int totalSum = 0;
            
            for (int i = 0; i < path.Length - 1; i++)
            {
                totalSum += GetSumOfTwoEdges($"{path[i]}", $"{path[i+1]}");
            }
            
            return totalSum;
        }

        private int GetSumOfTwoEdges(string firstName, string secondName)
        {
            var firstVertex = _graph.FindVertex(firstName);

            foreach (var item in firstVertex.Edges)
            {
                if (secondName == item.ConnectedVertex.Name)
                {
                    return item.EdgeWeight;
                }
            }

            return 0;
        }
        
        public string FindShortestPath(Vertex startVertex, Vertex finishVertex)
        {
            InitVertexInformation();

            VertexInfo first = GetVertexInfo(startVertex);
            first.SumOfWeightEdges = 0;

            while (true)
            {
                VertexInfo current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }
            
            return GetPath(startVertex, finishVertex);
        }

      
        public void SetSumToNextVertex(VertexInfo info)
        {
            info.IsUnvisited = false;

            foreach (var item in info.Vertex.Edges)
            {
                VertexInfo nextInfo = GetVertexInfo(item.ConnectedVertex);
                var sum = info.SumOfWeightEdges + item.EdgeWeight;

                if (sum < nextInfo.SumOfWeightEdges)
                {
                    nextInfo.SumOfWeightEdges = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        }

       
        public string GetPath(Vertex startVertex, Vertex endVertex)
        {
            var path = endVertex.Name;

            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                path = endVertex.Name + path;
            }
            
            return path;
        }
    }
}
