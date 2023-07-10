using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Data.Models
{
    public class Solution
    {
        [Key]
        public int Id { get; set; }
        public Task? Task { get; set; }
        public DateTime SolutionDate { get; set; }
        public DateTime AcceptedDate { get; set; }
        public bool IsAccepted { get; set; }
        public Account? WhoAccepted { get; set; }
        public Account? Author { get; set; }
        public string? SolutionText { get; set; }
        public string? AdminNotes { get; set;}

    }
}
