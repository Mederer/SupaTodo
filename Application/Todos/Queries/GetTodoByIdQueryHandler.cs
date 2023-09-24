using Mapster;
using MediatR;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Repositories;

namespace SupaTodo.Application.Todos.Queries;

public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoDto?>
{
    private readonly ITodoRepository _todoRepository;

    public GetTodoByIdQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public Task<TodoDto?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_todoRepository.FindById(request.Id)?.Adapt<TodoDto>());
    }
}