using MediatR;
using SupaTodo.Application.Dtos;

namespace SupaTodo.Application.Todos.Queries;

public record GetTodoByIdQuery(Guid Id) : IRequest<TodoDto?>;