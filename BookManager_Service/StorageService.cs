
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
    public class StorageService : IStorageService
    {
        private readonly IStorageRepo _storageRepo;
        public StorageService()
        {
            _storageRepo =  new StorageRepo();
        }
        public IList<Storage> GetStorages()
        {
            return _storageRepo.GetStorages();
        }
        public void AddBookInStorage(BookInStorage bookInStorage)
        {
            _storageRepo.AddBookInStorage(bookInStorage);   
        }

        public int GetStorageIdByName(string name)
        {
            return _storageRepo.GetStorageIdByName(name);
        }
    }
}
