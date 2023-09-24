using MediatR;
using SupaTodo.Application.Dtos;

namespace SupaTodo.Application.Todos.Commands;

public record CreateTodoCommand(string Title) : IRequest<TodoDto?>;