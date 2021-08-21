namespace DijkstraAlgorithm
            
{
    class GraphVertexInfo
    {
        public GraphVertex Vertex { get; set; }

        public int SumWieghtEdges {get; set;}
        public bool IsVisitedVertex { get; set; }
        public GraphVertex PreviousVertex { get; set; }

        public GraphVertexInfo(GraphVertex vertex)
        {
            Vertex = vertex;
            SumWieghtEdges = int.MaxValue;
            IsVisitedVertex = true;
            PreviousVertex = null;
        }
    }
}