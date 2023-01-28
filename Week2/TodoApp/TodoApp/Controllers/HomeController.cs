using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.Models;
using TodoApp.Services;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoItemRepository _toDoItemRepository;

        public HomeController(ILogger<HomeController> logger, ITodoItemRepository todoItemRepository)
        {
            _logger = logger;
            _toDoItemRepository = todoItemRepository;
        }

        public IActionResult ToDoList()
        {
            IEnumerable<ToDo> toDos = _toDoItemRepository.ToDoList();
            TodoVM todoVM = new TodoVM();
            todoVM.todos = toDos;
            return View(todoVM);
        }

        

        [HttpPost]
        public IActionResult Create(ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ToDoList");
            }
            else
            {
                _toDoItemRepository.AddItem(toDo);
                return RedirectToAction("ToDoList");
            }
        }
        [HttpGet]
        public IActionResult Toggle(Guid toDoId)
        {
            _toDoItemRepository.ToggleIsDone(toDoId);
            return RedirectToAction("ToDoList");

        }
        [HttpGet]
        public IActionResult Delete(Guid toDoId)
        {
            _toDoItemRepository.Delete(toDoId);
            return RedirectToAction("ToDoList");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}