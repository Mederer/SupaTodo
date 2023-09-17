namespace SupaTodo.Application.Dtos;

public record class UpdateTodoDto(Guid Id, string Title, bool IsComplete);
