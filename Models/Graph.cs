using System.Collections.Generic;

namespace GraphDataStructure.Models
{
    public class Graph
    {
        public List<Vertex> vertices;
        public List<Edge> edges;

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }
    }
}