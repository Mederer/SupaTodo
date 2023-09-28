using SupaTodo.Application.Repositories;
using SupaTodo.Domain.Entities;
using SupaTodo.Infrastructure.Persistence;

namespace SupaTodo.Infrastructure.Repositories;

public class TodoDbRepository : ITodoRepository
{
    private readonly SupaTodoContext _context;

    public TodoDbRepository(SupaTodoContext context)
    {
        _context = context;
    }

    public Todo? FindById(Guid id)
    {
        return _context.Todos.Find(id);
    }

    public Todo Save(Todo todo)
    {
        var insertedTodo = _context.Todos.Add(todo).Entity;
        _context.SaveChanges();
        return insertedTodo;
    }

    public List<Todo> FindAll()
    {
        return _context.Todos.ToList();
    }

    public bool Delete(Guid id)
    {
        var todo = _context.Todos.Find(id);

        if (todo is null)
        {
            return false;
        }

        _context.Todos.Remove(todo);
        return true;
    }
}