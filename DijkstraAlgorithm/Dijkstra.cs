using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    class Dijkstra
    {
        Graph graph;
        List<GraphVertexInfo> infos;

        public Dijkstra(Graph graph)
        {
            this.graph = graph;
        }

        void InitInfos()
        {
            infos = new List<GraphVertexInfo>();
            foreach(GraphVertex v in graph.Vertices)
            {
                infos.Add(new GraphVertexInfo(v));
            }
        }
        GraphVertexInfo GetVertexInfo(GraphVertex v)
        {
            foreach(GraphVertexInfo i in infos)
            {
                if(i.Vertex.Equals(v))
                {
                    return i;
                }
            }
            return null;
        }

        public GraphVertexInfo FindUnVisitedVertexWithMinSum()
        {
            int minValue = int.MaxValue;
            GraphVertexInfo minVertexInfo = null;
            foreach (var i in infos)
            {
                if (i.IsVisitedVertex && i.SumWieghtEdges < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.SumWieghtEdges;
                }
            }
            return minVertexInfo;
        }
        public string FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(graph.FindVertex(startName), graph.FindVertex(finishName));
        }
        public string FindShortestPath(GraphVertex startVertex, GraphVertex finishVertex)
        {
            InitInfos();
            var first = GetVertexInfo(startVertex);
            first.SumWieghtEdges = 0;
            while (true)
            {
                var current = FindUnVisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetPath(startVertex, finishVertex);
        } 
        void SetSumToNextVertex(GraphVertexInfo info)
        {
            info.IsVisitedVertex = false;
            foreach (var e in info.Vertex.Edges)
            {
                var nextInfo = GetVertexInfo(e.ConnectedVertex);
                var sum = info.SumWieghtEdges + e.EdgeWeight;
                if (sum < nextInfo.SumWieghtEdges)
                {
                    nextInfo.SumWieghtEdges = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
        } 
        string GetPath(GraphVertex startVertex, GraphVertex endVertex)
        {
            var path = endVertex.ToString();
            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                path = endVertex.ToString() + path;
            }

            return path;
        }
    }
}