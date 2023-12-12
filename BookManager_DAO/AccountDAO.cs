using BookManager_Model;
using BookManager_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_DAO
{
    public class AccountDAO 
    {
        private readonly BookManagerDBContext _dbContext;
        private readonly DbSet<Account> _dbset;
        public AccountDAO()
        {
            _dbContext = new BookManagerDBContext();
            _dbset = _dbContext.Set<Account>();
        }
        public Account GetAccountByUsernameAndPassword(string username, string password)
        {
            try
            {
                return _dbContext.Accounts.FirstOrDefault(a => a.Username.Equals(username) && password.Equals(password));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IList<Account> GetAccounts()
        {
            try
            {
                return _dbContext.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateAccount(Account account)
        {
            try
            {
                _dbset.Update(account);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
