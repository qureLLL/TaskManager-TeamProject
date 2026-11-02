using System;

namespace TaskManager.Models
{
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    public enum TaskStatus
    {
        Backlog,
        ToDo,
        InProgress,
        Review,
        Done
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}