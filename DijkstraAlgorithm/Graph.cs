using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    class Graph 
    {
        public List<GraphVertex> Vertices {get;}
        public Graph()
        {
            Vertices = new List<GraphVertex>();
        }

        public void AddVertex(string vertexName)
        {
            Vertices.Add(new GraphVertex(vertexName));
        }
        public GraphVertex FindVertex(string vertexName)
        {
            foreach(GraphVertex v in Vertices)
            {
                if(v.Name == vertexName)
                {
                    return v;
                }
            }
            return null;
        }
        public void AddEdge(string first, string second, int weight)
        {
            GraphVertex firstVertex = FindVertex(first);
            GraphVertex secondVertex = FindVertex(second);
            if(firstVertex !=null && secondVertex != null && firstVertex != secondVertex)
            {
                firstVertex.AddEdge(secondVertex,weight);
                //secondVertex.AddEdge(firstVertex,weight);
            }
        }
    }
}