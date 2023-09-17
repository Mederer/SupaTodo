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

        return new TodoDto(todo.Id, todo.Title, todo.IsComplete, todo.CreatedAt, todo.LastModified);
    }

    public bool DeleteTodo(Guid id)
    {
        return _todoRepository.Delete(id);
    }

    public List<TodoDto> GetAllTodos()
    {
        return _todoRepository.FindAll().ConvertAll(todo => new TodoDto(
            todo.Id,
            todo.Title,
            todo.IsComplete,
            todo.CreatedAt,
            todo.LastModified));
    }

    public TodoDto? GetTodo(Guid id)
    {
        if (_todoRepository.FindById(id) is Todo todo)
        {
            return new TodoDto(
                id,
                todo.Title,
                todo.IsComplete,
                todo.CreatedAt,
                todo.LastModified);
        }
        return null;
    }

    public TodoDto? UpdateTodo(UpdateTodoDto updateTodoDto)
    {
        if (_todoRepository.FindById(updateTodoDto.Id) is Todo todo)
        {
            todo.Title = updateTodoDto.Title;
            todo.IsComplete = updateTodoDto.IsComplete;
            todo.LastModified = _dateTimeProvider.GetCurrent();

            return new TodoDto(
                todo.Id,
                todo.Title,
                todo.IsComplete,
                todo.CreatedAt,
                todo.LastModified);
        }
        else
        {
            return null;
        }
    }
}
