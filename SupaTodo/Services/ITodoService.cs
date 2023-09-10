using SupaTodo.Entities;
using SupaTodo.Requests;

namespace SupaTodo.Services
{
    public interface ITodoService
    {
        Todo Create(CreateTodoRequest request);
        Todo? GetById(Guid id);
        List<Todo> GetAll();
        Todo? Update(UpdateTodoRequest request);
        bool DeleteTodo(Guid id);
    }
}
