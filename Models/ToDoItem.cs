using System;

namespace WPF_ToDoList.Models
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
