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
    public class BookDAO
    {
        private readonly BookManagerDBContext _context;
        private readonly DbSet<Book> _dbset;
        public BookDAO()
        {
            _context = new BookManagerDBContext();
            _dbset = _context.Set<Book>();
        }
        public IList<BookDTO> GetBooksWithQuantity()
        {
            try
            {
                IList<BookDTO> list = new List<BookDTO>();
                
                IList<Book> books = _context.Books.ToList();
                foreach (var book in books)
                {
                    var booksInStorage = _context.BookInStorages.Where(b => b.BookId == book.Id).ToList();
                    int? quantity = 0;
                    foreach(var bookinstorage in booksInStorage)
                    {
                        quantity += bookinstorage.Quantity;
                    }
                    var bookDTO = new BookDTO()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Author = book.Author,
                        ReleaseYear = book.ReleaseYear,
                        Price = book.Price,
                        Quantity = quantity
                    };
                    list.Add(bookDTO);
                }return list;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void AddBook(Book book)
        {
            try
            {
                _dbset.Add(book);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
