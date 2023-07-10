using Microsoft.EntityFrameworkCore;
using TaskMaster.Data.Interfaces;
using TaskMaster.Data.Models;
using TaskMaster.Migrations;

namespace TaskMaster.Data.Repository
{
    public class SolutionRepository : ISolutions
    {
        private readonly AppDBContent appDBContent;
        public SolutionRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Solution> AllSolutions => appDBContent.Solution.Include(s => s.Task).Include(s => s.Author).Include(s => s.WhoAccepted);

        public IEnumerable<Solution> GetSolutionsByAuthor(int id) => appDBContent.Solution.Include(s => s.Task).Include(s => s.Author).Where(a => a.Author.Id == id);

        public IEnumerable<Solution> GetSolutionsByTaskID(int id) => appDBContent.Solution.Include(s => s.Task).Include(s => s.Author).Where(a => a.Task.Id == id);

        public void AddSolution (Solution solution)
        {
            appDBContent.Solution.Add(solution);
            appDBContent.SaveChanges();
        }

        public Solution? GetSolutionById(int id) => appDBContent.Solution
        .Include(s => s.Task)
        .Include(s => s.WhoAccepted)
        .Include(s => s.Author)
        .FirstOrDefault(a => a.Id == id);
        public void UpdateSolution(Solution solution)
        {
            var existingSolution = appDBContent.Solution.FirstOrDefault(s => s.Id == solution.Id);
            if (existingSolution != null)
            { 
                existingSolution.AcceptedDate = solution.AcceptedDate;
                existingSolution.IsAccepted = solution.IsAccepted;
                existingSolution.WhoAccepted = solution.WhoAccepted;
                existingSolution.AdminNotes = existingSolution.AdminNotes.ToString() + "\n" + solution.AdminNotes.ToString();

                appDBContent.SaveChanges();
            }
        }
    }
}
