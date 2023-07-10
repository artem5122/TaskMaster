using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Data.Models
{
    public class Task
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set;}    
        public DateTime? DeadlineDate { get; set;}
        public uint? Price { get; set; }
        public Account? TaskAuthor { get; set; }
    }
}
