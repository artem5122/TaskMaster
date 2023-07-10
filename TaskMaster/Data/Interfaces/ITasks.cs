using TaskMaster.Data.Models;

namespace TaskMaster.Data.Interfaces
{
    public interface ITasks
    {
        IEnumerable<Task> AllTasks { get;}
        Task? GetTask(int id);
        public void AddTask(Task task);
    }
}
