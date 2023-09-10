using Microsoft.VisualBasic;
using SupaTodo.Validation;
using System.ComponentModel.DataAnnotations;

namespace SupaTodo.Requests
{
    public record CreateTodoRequest
    {
        [StringLength(10, MinimumLength = 2)]
        public string Title { get; set; } = null!;
        [TodoCompleteBy]
        public DateTime? CompleteBy { get; set; }
    }
}
