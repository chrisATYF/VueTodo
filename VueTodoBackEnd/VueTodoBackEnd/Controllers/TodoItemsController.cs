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
using VueTodoBackEnd.Services.Interfaces;

namespace VueTodoBackEnd.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : Controller
    {
        protected readonly ITodo _efTodoService;

        public TodoItemsController(ITodo efTodoService)
        {
            _efTodoService = efTodoService;
        }

        // GET all todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return Ok(await _efTodoService.GetTodoItems());
        }

        // GET todo by id
        [HttpGet("id")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var model = await _efTodoService.GetItem(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // Post new todos
        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodo([FromBody] TodoItem model)
        {
            if (model == null)
            {
                return BadRequest(model);
            }
            if (model.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            await _efTodoService.AddItem(model);

            return Ok(model);
        }

        // Update todo by id
        [HttpPut("id")]
        public async Task<ActionResult<TodoItem>> EditTodo(int id, TodoItem model)
        {
            if (model == null)
            {
                return BadRequest(model);
            }
            await _efTodoService.UpdateItem(id, model);
            var modelUpdated = await _efTodoService.GetItem(id);

            return Ok(modelUpdated);
        }

        // Remove a todo by id
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var model = await _efTodoService.GetItem(id);

            if (model == null)
            {
                return BadRequest(model);
            }

            _efTodoService.DeleteItem(id);

            return Ok();
        }
    }
}
