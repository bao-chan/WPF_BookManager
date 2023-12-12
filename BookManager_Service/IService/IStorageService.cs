using BookManager_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_Service.IService
{
    public interface IStorageService
    {
        public IList<Storage> GetStorages();
        public void AddBookInStorage(BookInStorage bookInStorage);
        public int GetStorageIdByName(string name);
    }
}
