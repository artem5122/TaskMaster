using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Data.Models
{
    public class Account
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
        public string? Img { get; set; }


    }
}
