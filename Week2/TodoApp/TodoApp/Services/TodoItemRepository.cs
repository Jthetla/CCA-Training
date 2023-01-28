using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public TodoItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddItem(ToDo toDo)
        {
            toDo.isCompleted = false;
            toDo.ToDoId = Guid.NewGuid();

            _appDbContext.ToDos.Add(toDo);
            _appDbContext.SaveChanges();
        }

        

        public void Delete(Guid toDoId)
        {
            ToDo toDo = _appDbContext.ToDos.FirstOrDefault(t => t.ToDoId.Equals(toDoId));
            _appDbContext.ToDos.Remove(toDo);
            _appDbContext.SaveChanges();
        }

        

        public IEnumerable<ToDo> ToDoList()
        {
            return _appDbContext.ToDos.ToArray();
        }

        public void ToggleIsDone(Guid toDoId)
        {
            ToDo toDo = _appDbContext.ToDos.FirstOrDefault(todo=> todo.ToDoId.Equals(toDoId));
            toDo.isCompleted = !toDo.isCompleted;
            _appDbContext.ToDos.Update(toDo);
            _appDbContext.SaveChanges();
        }
    }
}
