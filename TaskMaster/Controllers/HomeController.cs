using Microsoft.AspNetCore.Mvc;
using TaskMaster.Data.Interfaces;
using TaskMaster.ViewModel;

namespace TaskMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITasks _allTasks;
        private readonly IAccounts _allAccounts;
        //Вместе с интерфейсом мы передаём класс, который его реализует(TaskRepository и AccountRepository),
        //потому что в Program было прописано AddTransient<ITasks, TaskRepository>();
        public HomeController(ITasks tasks, IAccounts account)
        {
            _allAccounts = account;
            _allTasks = tasks;
        }

        public ViewResult Index()
        {
            TasksListViewModel obj = new();
            obj.AllTasks = _allTasks.AllTasks;
            ViewBag.Title = "Все задания";
            //Передаём все наши таски во view
            return View(obj); //Возвращается просто HTML страница
        }
    }
}
