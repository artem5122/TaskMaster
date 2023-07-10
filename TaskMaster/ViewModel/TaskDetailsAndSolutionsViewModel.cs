using TaskMaster.Data.Models;

namespace TaskMaster.ViewModel
{
    public class TaskDetailsAndSolutionsViewModel
    {
        public Task? Task { get; set; }
        public IEnumerable<Solution?>? TaskSolutions { get; set; }
    }
}
