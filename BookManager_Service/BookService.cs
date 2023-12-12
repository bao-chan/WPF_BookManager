using BookManager_Model;
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
    public class BookService : IBookService
    {
        private readonly IBookRepo _repo;
        public BookService()
        {
            _repo = new BookRepo();
        }

        public IList<BookDTO> GetBooksWithQuantity()
        {
            return _repo.GetBooksWithQuantity();
        }
        public void AddBook(Book book)
        {
            _repo.AddBook(book);
        }
    }
}
