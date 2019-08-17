using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphDataStructure.Models.Shared;
using GraphDataStructure.Models.DbContexts;

namespace GraphDataStructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphsController : ControllerBase
    {
        private readonly DevDbContext _devDbContext;
        private readonly StageDbContext _stageDbContext;
        private readonly MappedGraphsDbContext _mappedGraphsDbContext;

        public GraphsController(DevDbContext devDbContext, StageDbContext stageDbContext, MappedGraphsDbContext mappedGraphsDbContext)
        {
            _mappedGraphsDbContext = mappedGraphsDbContext;
            _stageDbContext = stageDbContext;
            _devDbContext = devDbContext;

            // seeding dev db
            if (_devDbContext.Vertices.Count() == 0)
            {
                _devDbContext.Vertices.Add(new Vertex { Name = "A" });
                _devDbContext.Vertices.Add(new Vertex { Name = "B" });
                _devDbContext.Vertices.Add(new Vertex { Name = "C" });
                _devDbContext.Vertices.Add(new Vertex { Name = "D" });
                _devDbContext.Vertices.Add(new Vertex { Name = "E" });
                _devDbContext.Vertices.Add(new Vertex { Name = "F" });
                _devDbContext.SaveChanges();
            }

            if (_devDbContext.Edges.Count() == 0)
            {
                var vertexA = _devDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "A");
                var vertexB = _devDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "B");
                var vertexC = _devDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "C");
                var vertexD = _devDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "D");
                var vertexE = _devDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "E");
                var vertexF = _devDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "F");

                _devDbContext.Edges.Add(new Edge { VertexA = vertexA, VertexB = vertexB });
                _devDbContext.Edges.Add(new Edge { VertexA = vertexA, VertexB = vertexD });
                _devDbContext.Edges.Add(new Edge { VertexA = vertexB, VertexB = vertexF });
                _devDbContext.Edges.Add(new Edge { VertexA = vertexC, VertexB = vertexF });
                _devDbContext.Edges.Add(new Edge { VertexA = vertexC, VertexB = vertexE });
                _devDbContext.Edges.Add(new Edge { VertexA = vertexF, VertexB = vertexE });
                
                _devDbContext.SaveChanges();
            }

            // seeding stage db
            if (_stageDbContext.Vertices.Count() == 0)
            {
                _stageDbContext.Vertices.Add(new Vertex { Name = "A" });
                _stageDbContext.Vertices.Add(new Vertex { Name = "B" });
                _stageDbContext.Vertices.Add(new Vertex { Name = "C" });
                _stageDbContext.Vertices.Add(new Vertex { Name = "D" });
                _stageDbContext.Vertices.Add(new Vertex { Name = "E" });
                _stageDbContext.Vertices.Add(new Vertex { Name = "F" });
                _stageDbContext.SaveChanges();
            }

            if (_stageDbContext.Edges.Count() == 0)
            {
                var vertexA = _stageDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "A");
                var vertexB = _stageDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "B");
                // var vertexC = _stageDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "C");
                var vertexD = _stageDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "D");
                var vertexE = _stageDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "E");
                var vertexF = _stageDbContext.Vertices.FirstOrDefault(vertex => vertex.Name == "F");

                _stageDbContext.Edges.Add(new Edge { VertexA = vertexA, VertexB = vertexB });
                _stageDbContext.Edges.Add(new Edge { VertexA = vertexA, VertexB = vertexD });
                _stageDbContext.Edges.Add(new Edge { VertexA = vertexB, VertexB = vertexF });
                // _stageDbContext.Edges.Add(new Edge { VertexA = vertexC, VertexB = vertexF });
                // _stageDbContext.Edges.Add(new Edge { VertexA = vertexC, VertexB = vertexE });
                _stageDbContext.Edges.Add(new Edge { VertexA = vertexF, VertexB = vertexE });
                
                _stageDbContext.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Todo
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        // {
        //     return await _context.TodoItems.ToListAsync();
        // }

        // // GET: api/Todo/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        // {
        //     var todoItem = await _context.TodoItems.FindAsync(id);

        //     if (todoItem == null)
        //     {
        //         return NotFound();
        //     }

        //     return todoItem;
        // }

        // // POST: api/Todo
        // [HttpPost]
        // public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        // {
        //     _context.TodoItems.Add(item);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        // }

        // // PUT: api/Todo/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutTodoItem(long id, TodoItem item)
        // {
        //     if (id != item.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(item).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // // DELETE: api/Todo/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteTodoItem(long id)
        // {
        //     var todoItem = await _context.TodoItems.FindAsync(id);

        //     if (todoItem == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.TodoItems.Remove(todoItem);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }
    }
}