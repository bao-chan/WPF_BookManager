using BookManager_DAO;
using BookManager_Model.Models;
using BookManager_Repository;
using BookManager_Repository.IRepo;
using BookManager_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        public AccountService()
        {
            _accountRepo = new AccountRepo();
        }
        public Account GetAccountByUsernameAndPassword(string username, string password)
        {
            return _accountRepo.GetAccountByUsernameAndPassword(username, password);
        }

        public IList<Account> GetAccounts()
        {
            return _accountRepo.GetAccounts();
        }
        public void UpdateAccount(Account account)
        {
            _accountRepo.UpdateAccount(account);
        }
    }
}
