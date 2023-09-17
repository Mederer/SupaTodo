namespace SupaTodo.Presentation.Contracts;

public record UpdateTodoRequest(Guid Id, string Title, bool IsComplete);