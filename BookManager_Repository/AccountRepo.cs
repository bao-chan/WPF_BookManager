using BookManager_DAO;
using BookManager_Model.Models;
using BookManager_Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly AccountDAO _accountDAO;
        public AccountRepo()
        {
            _accountDAO = new AccountDAO();
        }
        public Account GetAccountByUsernameAndPassword(string username, string password)
        {
            return _accountDAO.GetAccountByUsernameAndPassword(username, password);
        }

        public IList<Account> GetAccounts()
        {
            return _accountDAO.GetAccounts();
        }

        public void UpdateAccount(Account account)
        {
            _accountDAO.UpdateAccount(account);
        }
    }
}
