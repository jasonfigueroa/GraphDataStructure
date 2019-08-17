using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphDataStructure.Models;

namespace GraphDataStructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphsController : ControllerBase
    {
        private readonly GraphDSContext _context;

        public GraphsController(GraphDSContext context)
        {
            _context = context;

            if (_context.Vertices.Count() == 0)
            {
                _context.Vertices.Add(new Vertex { Name = "A" });
                _context.Vertices.Add(new Vertex { Name = "B" });
                _context.Vertices.Add(new Vertex { Name = "C" });
                _context.Vertices.Add(new Vertex { Name = "D" });
                _context.Vertices.Add(new Vertex { Name = "E" });
                _context.Vertices.Add(new Vertex { Name = "F" });
                _context.SaveChanges();
            }

            if (_context.Edges.Count() == 0)
            {
                var vertexA = _context.Vertices.FirstOrDefault(vertex => vertex.Name == "A");
                var vertexB = _context.Vertices.FirstOrDefault(vertex => vertex.Name == "B");
                var vertexC = _context.Vertices.FirstOrDefault(vertex => vertex.Name == "C");
                var vertexD = _context.Vertices.FirstOrDefault(vertex => vertex.Name == "D");
                var vertexE = _context.Vertices.FirstOrDefault(vertex => vertex.Name == "E");
                var vertexF = _context.Vertices.FirstOrDefault(vertex => vertex.Name == "F");
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Edges.Add(new Edge { VertexA = vertexA, VertexB = vertexB });
                _context.Edges.Add(new Edge { VertexA = vertexA, VertexB = vertexD });
                _context.Edges.Add(new Edge { VertexA = vertexB, VertexB = vertexF });
                _context.Edges.Add(new Edge { VertexA = vertexC, VertexB = vertexF });
                _context.Edges.Add(new Edge { VertexA = vertexC, VertexB = vertexE });
                _context.Edges.Add(new Edge { VertexA = vertexF, VertexB = vertexE });
                
                _context.SaveChanges();
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