using Microsoft.EntityFrameworkCore;

namespace GraphDataStructure.Models.DbContexts
{
    public class MappedGraphsDbContext : DbContext
    {
        public MappedGraphsDbContext(DbContextOptions<MappedGraphsDbContext> options)
            : base(options)
        {
        }

        public DbSet<MappedGraph> MappedGraphs { get; set; }
    }
}