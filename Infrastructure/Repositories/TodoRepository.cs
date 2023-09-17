using SupaTodo.Application.Repositories;
using SupaTodo.Domain.Entities;

namespace SupaTodo.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private static List<Todo> _todoList = new();

    public List<Todo> FindAll()
    {
        return _todoList;
    }

    public Todo? FindById(Guid id)
    {
        return _todoList.Find(todo => todo.Id == id);
    }

    public Todo Save(Todo todo)
    {
        _todoList.Add(todo);
        return todo;
    }

    public bool Delete(Guid id)
    {
        var todo = _todoList.Find(todo => todo.Id == id);

        if (todo is null)
        {
            return false;
        }
        else
        {
            _todoList.Remove(todo);
            return true;
        }
    }
}