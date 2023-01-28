using TodoApp.Models;

namespace TodoApp.Services
{
    public interface ITodoItemRepository
    {
        public IEnumerable<ToDo> ToDoList();
        public void AddItem(ToDo toDo);
        void ToggleIsDone(Guid toDoId);
        void Delete(Guid toDoId);
    }
}
