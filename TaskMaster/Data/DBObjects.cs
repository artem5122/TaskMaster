using TaskMaster.Data.Models;

namespace TaskMaster.Data
{
    public class DBObjects
    {
        public static void Initial(IApplicationBuilder app)
        {

            AppDBContent content = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDBContent>();
                
            if (!content.Account.Any())
            {
                content.Account.AddRange(Accounts.Select(c => c.Value));
            }
			

            if (!content.Task.Any())
            {
                content.AddRange(
                    new Task
                    {
                        Title = "Создать программу, чтоб круто было!",
                        Price = 100000,
                        Description = "Задачу необходимо выполнить очень скоро!",
                        CreatedDate = DateTime.Now,
                        DeadlineDate = DateTime.Now.AddDays(10),
                        //Accepted = true,
                        //SolutionAuthor = account["Павлик"],
                        TaskAuthor = account["Гриша"]
                    },
                    new Task
                    {
                        Title = "Создать сайт!",
                        Price = 150000,
                        Description = "Задачу необходимо выполнить очень скоро!",
                        CreatedDate = DateTime.Now,
                        DeadlineDate = DateTime.Now.AddDays(10),
                        //Accepted = true,
                        //SolutionAuthor = account["Павлик"],
                        TaskAuthor = account["Гоша"]
                    }, new Task
                    {
                        Title = "Необходимо решить Leetcode задачу!",
                        Price = 20000,
                        Description = "Задачу необходимо выполнить очень скоро!",
                        CreatedDate = DateTime.Now,
                        DeadlineDate = DateTime.Now.AddDays(10),
                        //Accepted = true,
                        //SolutionAuthor = account["Иннокентий"],
                        TaskAuthor = account["Гоша"]
                    }, new Task
                    {
                        Title = "Разработать сайт на ASP.NET!",
                        Price = 200000000,
                        Description = "Задачу необходимо выполнить очень скоро!",
                        CreatedDate = DateTime.Now,
                        DeadlineDate = DateTime.Now.AddDays(10),
                        //Accepted = true,
                        //SolutionAuthor = account["Павлик"],
                        TaskAuthor = account["Гриша"]
                    }, new Task
                    {
                        Title = "Необходимо написать программу!",
                        Price = 20000,
                        Description = "Задачу необходимо выполнить очень скоро!",
                        CreatedDate = DateTime.Now,
                        DeadlineDate = DateTime.Now.AddDays(10),
                        //Accepted = true,
                        //SolutionAuthor = account["Иннокентий"],
                        TaskAuthor = account["Гриша"]
                    }, new Task
                    {
                        Title = "Нужно написать эффективную программу!",
                        Price = 20000,
                        Description = "Задачу необходимо выполнить очень скоро!",
                        CreatedDate = DateTime.Now,
                        DeadlineDate = DateTime.Now.AddDays(10),
                        //Accepted = true,
                        //SolutionAuthor = account["Павлик"],
                        TaskAuthor = account["Гоша"]
                    },
                    new Task
                    {
                        Title = "Необходимо написать программу!",
                        Price = 20000,
                        Description = "Задачу необходимо выполнить очень скоро!",
                        CreatedDate = DateTime.Now,
                        DeadlineDate = DateTime.Now.AddDays(10),
                        //Accepted = true,
                        //SolutionAuthor = account["Павлик"],
                        TaskAuthor = account["Гриша"]
                    }
                );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Account>? account;
        public static Dictionary<string, Account> Accounts
        {
            get
            {
                if(account == null )
                {
                    var list = new Account[]
                    {
                        new Account { Name = "Гриша",      Email = "example@ex.com", Password = "example", IsAdmin = true,  Img = "/img/admin.png" },
                        new Account { Name = "Гоша",       Email = "example@ex.com", Password = "example", IsAdmin = true,  Img = "/img/admin.png" },
                        new Account { Name = "Павлик",     Email = "example@ex.com", Password = "example", IsAdmin = false, Img = "/img/programmer.png" },
                        new Account { Name = "Иннокентий", Email = "example@ex.com", Password = "example", IsAdmin = false, Img = "/img/programmer.png" }
                    };
                    account = new Dictionary<string, Account>();
                    foreach(Account el in list)
                        account.Add( el.Name, el );
                }
                return account;
            }
        }
        
    }
}
