using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;
using VueTodoBackEnd.Models;

namespace VueTodoBackEnd.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : Controller
    {
        private readonly TodoDbContext _context;

        public TodoItemsController(TodoDbContext context)
        {
            _context = context;
        }

        // GET all todos
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return Ok(_context.TodoItems.ToList());
        }

        // GET todo by id
        [HttpGet("id")]
        public ActionResult<TodoItem> GetTodoItem(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var model = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // Post new todos
        [HttpPost]
        public ActionResult<TodoItem> CreateTodo([FromBody] TodoItem model)
        {
            if (model == null)
            {
                return BadRequest(model);
            }
            if (model.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _context.TodoItems.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }

        // Update todo by id
        [HttpPut("id")]
        public ActionResult<TodoItem> EditTodo(TodoItem model)
        {
            var modelToUpdate = _context.TodoItems.FirstOrDefault(t => t.Id == model.Id);
            modelToUpdate.Id = model.Id;
            modelToUpdate.Title = model.Title;
            modelToUpdate.Note = model.Note;
            modelToUpdate.IsComplete = model.IsComplete;

            _context.SaveChanges();

            return Ok(modelToUpdate);
        }

        // Remove a todo by id
        [HttpDelete("id")]
        public ActionResult DeleteTodo(int id)
        {
            var model = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            _context.TodoItems.Remove(model);
            _context.SaveChanges();

            return Ok();
        }
    }
}
