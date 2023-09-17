namespace SupaTodo.Domain.Entities;

public class Todo
{
  public Guid Id { get; init; } = Guid.NewGuid();
  public string Title { get; set; } = null!;
  public bool IsComplete { get; set; }
  public DateTime CreatedAt { get; init; }
  public DateTime LastModified { get; set; }
}