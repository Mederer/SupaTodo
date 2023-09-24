using Mapster;
using MediatR;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Interfaces;
using SupaTodo.Application.Repositories;
using SupaTodo.Domain.Entities;

namespace SupaTodo.Application.Todos.Commands;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoDto?>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateTodoCommandHandler(ITodoRepository todoRepository, IDateTimeProvider dateTimeProvider)
    {
        _todoRepository = todoRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public Task<TodoDto?> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var newTodo = new Todo()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            CreatedAt = _dateTimeProvider.UtcNow(),
            LastModified = _dateTimeProvider.UtcNow(),
            IsComplete = false
        };
        _todoRepository.Save(newTodo);
        return Task.FromResult(newTodo.Adapt<TodoDto?>());
    }
}