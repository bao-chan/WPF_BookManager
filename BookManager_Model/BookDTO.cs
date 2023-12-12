using BookManager_Model.Models;
using System;
using System.Collections.Generic;

namespace BookManager_Model
{
    public partial class BookDTO
    {
        public BookDTO()
        {
            BookInStorages = new HashSet<BookInStorage>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? ReleaseYear { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }   

        public virtual ICollection<BookInStorage> BookInStorages { get; set; }
    }
}
