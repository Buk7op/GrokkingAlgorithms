using System.Collections.Generic;

namespace DijktraAlgorithm
{
    class GraphVertex
    {
        public string Name { get; }

        public List<GraphEdge> Edges {get;}

        public GraphVertex(string name)
        {
            Name = name;
            Edges = new List<GraphEdge>();
        }

        public void  AddEdge(GraphEdge edge)
        {
            Edges.Add(edge);
        }

        public void AddEdge(GraphVertex vertex, int weight)
        {
            Edges.Add(new GraphEdge(vertex,weight));
        }
        public override string ToString() => Name;
        
    }
}