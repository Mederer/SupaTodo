using Mapster;
using MediatR;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Repositories;

namespace SupaTodo.Application.Todos.Queries;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<TodoDto>>
{
    private readonly ITodoRepository _todoRepository;

    public GetTodosQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public Task<List<TodoDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_todoRepository.FindAll().Adapt<List<TodoDto>>());
    }
}