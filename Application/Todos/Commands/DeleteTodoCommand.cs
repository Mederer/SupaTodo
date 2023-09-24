using MediatR;

namespace SupaTodo.Application.Todos.Commands;

public record DeleteTodoCommand(Guid Id) : IRequest<bool>;