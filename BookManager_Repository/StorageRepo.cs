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
    public class StorageRepo : IStorageRepo
    {
        private readonly StorageDAO _storageDAO;
        public StorageRepo()
        {
            _storageDAO = new StorageDAO();
        }
        public IList<Storage> GetStorages()
        {
            return _storageDAO.GetStorages();
        }
        public void AddBookInStorage(BookInStorage bookInStorage)
        {
            _storageDAO.AddBookInStorage(bookInStorage);
        }

        public int GetStorageIdByName(string name)
        {
            return _storageDAO.GetStorageIdByName(name);
        }
    }
}
