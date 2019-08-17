using GraphDataStructure.Models.Shared;

namespace GraphDataStructure.Models
{
    public class MappedGraph
    {
        public long Id { get; set; }
        public Graph DevDbGraph { get; set; }
        public Graph StageDbGraph { get; set; }
    }
}