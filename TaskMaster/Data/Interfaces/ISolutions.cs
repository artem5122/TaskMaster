using TaskMaster.Data.Models;

namespace TaskMaster.Data.Interfaces
{
    public interface ISolutions
    {
        IEnumerable<Solution> AllSolutions { get;}
        IEnumerable<Solution> GetSolutionsByTaskID(int id);
        IEnumerable<Solution> GetSolutionsByAuthor(int id);
        void AddSolution(Solution newSolution);
        Solution? GetSolutionById(int id);
        public void UpdateSolution(Solution solution);
    }
}
