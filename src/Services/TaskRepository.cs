using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskRepository
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        private int _nextId = 1;

        public TaskItem AddTask(string title, string description, string assignedTo, TaskPriority priority)
        {
            var item = new TaskItem
            {
                Id = _nextId++,
                Title = title,
                Description = description,
                AssignedTo = assignedTo,
                Priority = priority,
                Status = TaskStatus.ToDo,
                CreatedAt = DateTime.UtcNow
            };
            _tasks.Add(item);
            return item;
        }

        public IReadOnlyList<TaskItem> GetAll() => _tasks.AsReadOnly();

        public IEnumerable<TaskItem> GetByAssignee(string assignee) =>
            _tasks.Where(t => string.Equals(t.AssignedTo, assignee, StringComparison.OrdinalIgnoreCase));

        public bool UpdateStatus(int id, TaskStatus newStatus)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return false;

            task.Status = newStatus;
            return true;
        }
    }
}
