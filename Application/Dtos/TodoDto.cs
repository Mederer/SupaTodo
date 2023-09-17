namespace SupaTodo.Application.Dtos;

public record TodoDto(
    Guid Id,
    string Title,
    bool IsComplete,
    DateTime CreatedAt,
    DateTime LastModified);