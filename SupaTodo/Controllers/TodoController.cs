using Microsoft.AspNetCore.Mvc;
using SupaTodo.Entities;
using SupaTodo.Requests;
using SupaTodo.Services;
using System.Net.Mime;

namespace SupaTodo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    [Produces(MediaTypeNames.Application.Json)]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_todoService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            Todo? foundTodo = _todoService.GetById(id);

            return foundTodo is null ? NotFound() : Ok(foundTodo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateTodo(CreateTodoRequest request)
        {
            Todo newTodo = _todoService.Create(request);
            return CreatedAtAction(nameof(GetById), new { newTodo.Id }, newTodo);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateTodo(UpdateTodoRequest request)
        {
            Todo? updatedTodo = _todoService.Update(request);

            return updatedTodo is null ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTodo(Guid id)
        {
            bool wasDeleted = _todoService.DeleteTodo(id);
            return wasDeleted ? NoContent() : NotFound();
        }
    }
}
