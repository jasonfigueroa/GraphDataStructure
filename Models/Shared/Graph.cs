using System.Collections.Generic;

namespace GraphDataStructure.Models.Shared
{
    public class Graph
    {
        public long Id { get; set; }
        public List<Vertex> vertices;
        public List<Edge> edges;

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }
    }
}