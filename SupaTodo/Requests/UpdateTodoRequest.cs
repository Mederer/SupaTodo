using SupaTodo.Validation;
using System.ComponentModel.DataAnnotations;

namespace SupaTodo
{
    public record UpdateTodoRequest
    {
        public Guid Id { get; set; }
        [StringLength(10, MinimumLength = 2)]
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; }
        [TodoCompleteBy]
        public DateTime? CompleteBy { get; set; }
    }
}