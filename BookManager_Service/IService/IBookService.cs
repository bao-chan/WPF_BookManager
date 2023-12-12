using BookManager_Model;
using BookManager_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_Service.IService
{
    public interface IBookService 
    {
        public IList<BookDTO> GetBooksWithQuantity();
        public void AddBook(Book book);
    }
}
