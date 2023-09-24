using MediatR;
using Microsoft.AspNetCore.Mvc;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Interfaces;
using SupaTodo.Application.Todos.Queries;
using SupaTodo.Presentation.Contracts;

namespace SupaTodo.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
  private readonly ITodoService _todoService;
  private readonly ISender _mediator;

  public TodosController(ITodoService todoService, ISender mediator)
  {
    _todoService = todoService;
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllTodos()
  {
    var query = new GetTodosQuery();
    var todos = await _mediator.Send(query);
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

  [HttpPut]
  public IActionResult UpdateTodo(UpdateTodoRequest updateTodoRequest)
  {
    var updatedTodo = _todoService.UpdateTodo(new UpdateTodoDto(
        updateTodoRequest.Id,
        updateTodoRequest.Title,
        updateTodoRequest.IsComplete));

    return updatedTodo is not null ? Ok(updatedTodo) : NotFound();
  }
}