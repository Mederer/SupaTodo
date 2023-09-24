using MediatR;
using SupaTodo.Application.Dtos;

namespace SupaTodo.Application.Todos.Queries;

public record GetTodosQuery : IRequest<List<TodoDto>>;