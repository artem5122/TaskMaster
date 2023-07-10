using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskMaster.Data.Interfaces;
using TaskMaster.Data.Models;

namespace TaskMaster.Data.Repository
{
    public class AccountRepository : IAccounts
    {
        private readonly AppDBContent appDBContent;
        public AccountRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Account> AllAccounts => appDBContent.Account;
        public Account? FindByName(string name) => appDBContent.Account.FirstOrDefault(a => a.Name == name);
        public void AddAccount(Account account)
        {
            appDBContent.Account.Add(account);
            appDBContent.SaveChanges();
        }
    }
}
