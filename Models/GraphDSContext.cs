using Microsoft.EntityFrameworkCore;

namespace GraphDataStructure.Models
{
    public class GraphDSContext : DbContext
    {
        public GraphDSContext(DbContextOptions<GraphDSContext> options)
            : base(options)
        {
        }

        public DbSet<Vertex> Vertices { get; set; }
        public DbSet<Edge> Edges { get; set; }
        public DbSet<Graph> Graphs { get; set; }
    }
}