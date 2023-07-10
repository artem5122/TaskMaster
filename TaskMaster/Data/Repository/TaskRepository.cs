using Microsoft.EntityFrameworkCore;
using TaskMaster.Data.Interfaces;
using TaskMaster.Data.Models;

namespace TaskMaster.Data.Repository
{
    public class TaskRepository : ITasks
    {
        private readonly AppDBContent appDBContent;
        public TaskRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Task> AllTasks => appDBContent.Task.Include(t => t.TaskAuthor);
        public Task? GetTask(int id) => appDBContent.Task.Include(t => t.TaskAuthor).FirstOrDefault(p => p.Id == id);
        public void AddTask(Task task)
        {
            appDBContent.Task.Add(task);
            appDBContent.SaveChanges();
        }

    }
}
