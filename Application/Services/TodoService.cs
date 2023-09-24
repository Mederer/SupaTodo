using Mapster;
using SupaTodo.Application.Dtos;
using SupaTodo.Application.Repositories;
using SupaTodo.Application.Interfaces;
using SupaTodo.Domain.Entities;

namespace SupaTodo.Application.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public TodoService(ITodoRepository todoRepository, IDateTimeProvider dateTimeProvider)
    {
        _todoRepository = todoRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public TodoDto CreateTodo(CreateTodoDto createTodoDto)
    {
        var todo = new Todo
        {
            Id = Guid.NewGuid(),
            Title = createTodoDto.Title,
            CreatedAt = _dateTimeProvider.GetCurrent(),
            LastModified = _dateTimeProvider.GetCurrent(),
            IsComplete = false
        };
        _todoRepository.Save(todo);

        return todo.Adapt<TodoDto>();
    }

    public bool DeleteTodo(Guid id)
    {
        return _todoRepository.Delete(id);
    }

    public List<TodoDto> GetAllTodos()
    {
        var todos = _todoRepository.FindAll();
        return todos.Adapt<List<TodoDto>>();
    }

    public TodoDto? GetTodo(Guid id)
    {
        var todo = _todoRepository.FindById(id);

        return todo?.Adapt<TodoDto>();
    }

    public TodoDto? UpdateTodo(UpdateTodoDto updateTodoDto)
    {
        if (_todoRepository.FindById(updateTodoDto.Id) is Todo todo)
        {
            todo.Title = updateTodoDto.Title;
            todo.IsComplete = updateTodoDto.IsComplete;
            todo.LastModified = _dateTimeProvider.GetCurrent();

            return todo.Adapt<TodoDto>();
        }
        else
        {
            return null;
        }
    }
}
