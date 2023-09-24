using MediatR;
using Microsoft.AspNetCore.Mvc;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Interfaces;
using SupaTodo.Application.Todos.Commands;
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
        return Ok(todos);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetTodo(Guid id)
    {
        var todo = _todoService.GetTodo(id);

        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo(CreateTodoCommand command)
    {
        var newTodo = await _mediator.Send(command);
        return newTodo is not null ? Ok(newTodo) : BadRequest();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTodo(Guid id)
    {
        var command = new DeleteTodoCommand(id);
        var wasDeleted = await _mediator.Send(command);

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