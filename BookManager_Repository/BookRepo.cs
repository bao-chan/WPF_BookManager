using BookManager_DAO;
using BookManager_Model;
using BookManager_Model.Models;
using BookManager_Repository.IRepo;

namespace BookManager_Repository
{
    public class BookRepo : IBookRepo
    {
        private readonly BookDAO _dao;
        public BookRepo()
        {
            _dao = new BookDAO();
        }
        public IList<BookDTO> GetBooksWithQuantity()
        {
           return _dao.GetBooksWithQuantity();
        }
        public void AddBook(Book book) { _dao.AddBook(book); }
    }
}
