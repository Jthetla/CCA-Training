using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class ToDo
    {
        [Key]
        [Required]
        public Guid ToDoId { get; set; }

        [Required]
        public string toDoItem { get; set; }

        public bool isCompleted {get;set;}
    }
}
