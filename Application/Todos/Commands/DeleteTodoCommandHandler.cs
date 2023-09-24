using MediatR;
using SupaTodo.Application.Repositories;

namespace SupaTodo.Application.Todos.Commands;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_todoRepository.Delete(request.Id));
    }
}