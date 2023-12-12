using BookManager_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_Repository.IRepo
{
    public interface IAccountRepo
    {
        Account GetAccountByUsernameAndPassword(string username, string password);
        IList<Account> GetAccounts();
        public void UpdateAccount(Account account);
    }
}
