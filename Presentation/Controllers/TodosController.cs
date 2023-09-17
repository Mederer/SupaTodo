using Microsoft.AspNetCore.Mvc;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Interfaces;
using SupaTodo.Presentation.Contracts;

namespace SupaTodo.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
  private readonly ITodoService _todoService;

  public TodosController(ITodoService todoService)
  {
    _todoService = todoService;
  }

  [HttpGet]
  public IActionResult GetAllTodos()
  {
    return Ok(_todoService.GetAllTodos());
  }

  [HttpGet("{id:guid}")]
  public IActionResult GetTodo(Guid id)
  {
    var todo = _todoService.GetTodo(id);

    return todo is null ? NotFound() : Ok(todo);
  }

  [HttpPost]
  public IActionResult CreateTodo(CreateTodoRequest request)
  {
    var todo = _todoService.CreateTodo(new CreateTodoDto(request.Title));
    return Ok(todo);
  }

  [HttpDelete("{id:guid}")]
  public IActionResult DeleteTodo(Guid id)
  {
    var wasDeleted = _todoService.DeleteTodo(id);

    return wasDeleted ? NoContent() : NotFound();
  }
}