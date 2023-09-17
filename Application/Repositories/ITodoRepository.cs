using SupaTodo.Domain.Entities;

namespace SupaTodo.Application.Repositories;

public interface ITodoRepository
{
  Todo? FindById(Guid id);

  Todo Save(Todo todo);

  List<Todo> FindAll();

  bool Delete(Guid id);
}