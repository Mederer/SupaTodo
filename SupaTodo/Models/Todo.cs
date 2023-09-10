namespace SupaTodo.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime? CompleteBy { get; set; }

        public DateTime? CompletedAt { get; set; }

        public Todo(string title) : this(title, null) { }

        public Todo(string title, DateTime? completeBy)
        {
            Id = Guid.NewGuid();
            Title = title;
            CompleteBy = completeBy;

            IsCompleted = false;
        }
    }
}
