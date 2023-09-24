using MediatR;
using SupaTodo.Application.Dtos;

namespace SupaTodo.Application.Todos.Commands;

public record UpdateTodoCommand(Guid Id, string Title, bool IsComplete) : IRequest<TodoDto?>;