namespace DijktraAlgorithm
{
    class GraphEdge 
    {
        public GraphVertex ConnectedVertex { get; }
        public int EdgeWeight { get; }
        public GraphEdge(GraphVertex vertex, int weight)
        {
            ConnectedVertex = vertex;
            EdgeWeight = weight;
        }
    }
}