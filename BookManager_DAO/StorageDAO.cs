using BookManager_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_DAO
{
    public class StorageDAO
    {
        private readonly BookManagerDBContext _context;
        private readonly DbSet<BookInStorage> _dbset;
        public StorageDAO() 
        {
            _context = new BookManagerDBContext();
            _dbset = _context.Set<BookInStorage>(); 
        }
        public IList<Storage> GetStorages()
        {
            try
            {
                return _context.Storages.ToList();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message ,ex);
            }
        }
        public void AddBookInStorage(BookInStorage bookInStorage)
        {
            try
            {
                _dbset.Add(bookInStorage);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public int GetStorageIdByName(string name)
        {
            try
            {
                return _context.Storages.FirstOrDefault(s => s.Name.Equals(name)).Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
