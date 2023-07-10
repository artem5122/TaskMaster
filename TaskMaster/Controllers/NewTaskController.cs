using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using TaskMaster.Data.Interfaces;
using TaskMaster.Data.Models;
using TaskMaster.Data.Repository;
using TaskMaster.ViewModel;

namespace TaskMaster.Controllers
{
    public class NewTaskController : Controller
    {
        private readonly ITasks task;
        private readonly IAccounts account;
        private readonly ISolutions _solution;

        public NewTaskController(ITasks tasks, IAccounts account, ISolutions solution)
        {
            this.account = account;
            task = tasks;
            _solution = solution;
        }

        [HttpGet]
        public IActionResult Create()
        {
            NewTaskViewModel obj = new();
            return View(obj);
        }


        [HttpPost]
        public IActionResult Publish(string Title, string Description, DateTime DeadlineDate, int price, string Author)
        {
            Account acc = account.FindByName(Author);
            Task t = new Task
            {
                Title = Title,
                Description = Description,
                CreatedDate = DateTime.Now,
                DeadlineDate = DeadlineDate,
                Price = (uint?)price,
                TaskAuthor = acc
            };

            task.AddTask(t);

            return RedirectToAction("Index", "Home");
        }
    }
}
