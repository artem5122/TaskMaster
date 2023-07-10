using Microsoft.AspNetCore.Mvc;
using TaskMaster.Data.Interfaces;
using TaskMaster.Data.Models;
using TaskMaster.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;


namespace TaskMaster.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITasks task;
        private readonly IAccounts account;
        private readonly ISolutions _solution;

        public TaskController(ITasks tasks, IAccounts account, ISolutions solution)
        {
            this.account = account;
            task = tasks;
            _solution = solution;
        }

        public ActionResult Details(int id)
        {
            //Выводим на вью всю информацию о данном задании и его решения
            TaskDetailsAndSolutionsViewModel obj = new();
            obj.Task = task.GetTask(id);
            obj.TaskSolutions = _solution.GetSolutionsByTaskID(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult SubmitSolution(int taskId, string solutionText, string username)
        {
            
            var _task = task.GetTask(taskId);
            var _acc = account.FindByName(username);

            var newSolution = new Solution
            {
                Task = _task,
                SolutionDate = DateTime.Now,
                SolutionText = solutionText,
                Author = _acc,
                IsAccepted = false
            };

            _solution.AddSolution(newSolution);

            // Возвращаем пользователя на страницу деталей задания
            return RedirectToAction("Details", new { id = taskId });
        }
        [HttpPost]
        public ActionResult RateSolution(int solutionId, bool isAccepted, int taskId, string notes)
        {
            var solution = _solution.GetSolutionById(solutionId);
            if (solution == null)
            {
                return NotFound();
            }

            solution.IsAccepted = isAccepted;
            solution.AdminNotes = notes;

            if (isAccepted)
            {
                solution.AcceptedDate = DateTime.Now;
            }

            _solution.UpdateSolution(solution);

            return RedirectToAction("Details", new { id = taskId });
        }
    }
}
