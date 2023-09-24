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
    private readonly ISender _mediator;

    public TodosController(ISender mediator)
    {
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
    public async Task<IActionResult> GetTodo(Guid id)
    {
        var query = new GetTodoByIdQuery(id);
        var todo = await _mediator.Send(query);

        return todo is not null ? Ok(todo) : NotFound();
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
    public async Task<IActionResult> UpdateTodo(UpdateTodoCommand command)
    {
        var updatedTodo = await _mediator.Send(command);

        return updatedTodo is not null ? Ok(updatedTodo) : NotFound();
    }
}