using Mapster;
using MediatR;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Interfaces;
using SupaTodo.Application.Repositories;

namespace SupaTodo.Application.Todos.Commands;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoDto?>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository, IDateTimeProvider dateTimeProvider)
    {
        _todoRepository = todoRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public Task<TodoDto?> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = _todoRepository.FindById(request.Id);

        if (todo is null)
        {
            return Task.FromResult<TodoDto?>(null);
        }

        todo.Title = request.Title;
        todo.IsComplete = request.IsComplete;
        todo.LastModified = _dateTimeProvider.UtcNow();

        _todoRepository.Save(todo);

        return Task.FromResult(todo.Adapt<TodoDto?>());
    }
}