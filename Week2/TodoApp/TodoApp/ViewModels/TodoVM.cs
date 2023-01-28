using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class TodoVM
    {
        public IEnumerable<ToDo> todos { get; set; }
         
        public ToDo toDo { get; set; }

    }
}
