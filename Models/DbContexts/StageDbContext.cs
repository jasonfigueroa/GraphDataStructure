using Microsoft.EntityFrameworkCore;
using GraphDataStructure.Models.Shared;

namespace GraphDataStructure.Models.DbContexts
{
    public class StageDbContext : DbContext
    {
        public StageDbContext(DbContextOptions<StageDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vertex> Vertices { get; set; }
        public DbSet<Edge> Edges { get; set; }
        public DbSet<Graph> Graphs { get; set; }
    }
}