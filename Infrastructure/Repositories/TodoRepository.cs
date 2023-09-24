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
        var todoToUpdate = _todoList.Find(x => x.Id == todo.Id);

        if (todoToUpdate is null)
        {
            _todoList.Add(todo);
        }
        else
        {
            todoToUpdate = todo;
        }
        
        return todo;
    }

    public bool Delete(Guid id)
    {
        var todoToDelete = _todoList.Find(todo => todo.Id == id);

        if (todoToDelete is null)
        {
            return false;
        }

        _todoList.Remove(todoToDelete);
        return true;
    }
}