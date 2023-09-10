using SupaTodo.Db;
using SupaTodo.Entities;
using SupaTodo.Requests;

namespace SupaTodo.Services
{
    public class TodoService : ITodoService
    {
        private readonly SupaTodoContext _context;
        public TodoService(SupaTodoContext context)
        {
            _context = context;
        }

        public Todo Create(CreateTodoRequest request)
        {
            var todo = new Todo(request.Title, request.CompleteBy);
            _context.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        public bool DeleteTodo(Guid id)
        {
            var todo = _context.Todos.Find(id);
            if (todo is null)
            {
                return false;
            }

            _context.Remove(todo);
            _context.SaveChanges();
            return true;
        }

        public List<Todo> GetAll()
        {
            return _context.Todos.ToList();
        }

        public Todo? GetById(Guid id)
        {
            return _context.Todos.Find(id);
        }

        public Todo? Update(UpdateTodoRequest request)
        {
            var todo = _context.Todos.Find(request.Id);
            if (todo is null)
            {
                return null;
            }

            todo.Title = request.Title;
            todo.CompleteBy = request.CompleteBy;

            if (!todo.IsCompleted && request.IsCompleted)
            {
                todo.IsCompleted = true;
                todo.CompletedAt = DateTime.Now;
            }
            else
            {
                todo.IsCompleted = request.IsCompleted;
            }

            _context.SaveChanges();

            return todo;
        }
    }
}
