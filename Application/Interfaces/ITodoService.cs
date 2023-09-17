using SupaTodo.Application.Dtos;

namespace SupaTodo.Application.Interfaces;

public interface ITodoService
{
  TodoDto? GetTodo(Guid id);
  TodoDto CreateTodo(CreateTodoDto createTodoDto);

  List<TodoDto> GetAllTodos();

  bool DeleteTodo(Guid id);

  TodoDto? UpdateTodo(UpdateTodoDto updateTodoDto);
}