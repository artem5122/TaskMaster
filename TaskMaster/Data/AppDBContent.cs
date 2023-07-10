using Microsoft.EntityFrameworkCore;
using TaskMaster.Data.Models;

namespace TaskMaster.Data
{
    public class AppDBContent :DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options):base(options)
        {
            
        }
        public DbSet<Task> Task { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Solution> Solution { get; set; }
    }
}
