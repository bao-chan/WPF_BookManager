using BookManager_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_Service.IService
{
    public interface IAccountService
    {
        Account GetAccountByUsernameAndPassword(string username, string password);
        IList<Account> GetAccounts();
        public void UpdateAccount(Account account);
    }
}
