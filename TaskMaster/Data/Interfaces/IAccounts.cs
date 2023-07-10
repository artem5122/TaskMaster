using TaskMaster.Data.Models;

namespace TaskMaster.Data.Interfaces
{
    public interface IAccounts
    {
        IEnumerable<Account> AllAccounts { get; }
        public Account? FindByName(string name);
        public void AddAccount(Account account);

    }
}
