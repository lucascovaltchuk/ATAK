using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MeuTodo.Data;
using MeuTodo.Models;
using MeuTodo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuTodo.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Retorna um item de todo por ID
        [HttpGet("todos/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id)
        {
            var todo = await _context
                .Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return todo == null
                ? NotFound()
                : Ok(todo);
        }

        // GET: Retorna uma lista de todos filtrada e ordenada por data
        [HttpGet("todos")]
        public async Task<IActionResult> GetFilteredAndSortedTodosAsync(
            [FromQuery] string sortOrder)
        {
            IQueryable<Todo> todosQuery = _context.Todos.AsQueryable();

            // Filtrar e ordenar com base no campo 'date'
            switch (sortOrder)
            {
                case "asc":
                    todosQuery = todosQuery.OrderBy(x => x.Date);
                    break;
                case "desc":
                    todosQuery = todosQuery.OrderByDescending(x => x.Date);
                    break;
                default:
                    todosQuery = todosQuery.OrderBy(x => x.Id);
                    break;
            }

            var todos = await todosQuery.ToListAsync();
            return Ok(todos);
        }

        // POST: Cria um novo item de todo
        [HttpPost("todos")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreateTodoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = new Todo
            {
                Date = DateTime.Now,
                Title = model.Title,
                Desc = model.Desc,
                Status = model.Status
            };

            try
            {
                await _context.Todos.AddAsync(todo);
                await _context.SaveChangesAsync();
                return Created($"v1/todos/{todo.Id}", todo);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT: Atualiza um item de todo por ID
        [HttpPut("todos/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] CreateTodoViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null)
                return NotFound();

            try
            {
                todo.Title = model.Title;
                todo.Desc = model.Desc;
                todo.Status = model.Status;

                _context.Todos.Update(todo);
                await _context.SaveChangesAsync();
                return Ok(todo);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE: Remove um item de todo por ID
        [HttpDelete("todos/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
