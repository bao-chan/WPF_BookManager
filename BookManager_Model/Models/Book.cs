using System;
using System.Collections.Generic;

namespace BookManager_Model.Models
{
    public partial class Book
    {
        public Book()
        {
            BookInStorages = new HashSet<BookInStorage>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? ReleaseYear { get; set; }
        public decimal? Price { get; set; }
        public virtual ICollection<BookInStorage> BookInStorages { get; set; }
    }
}
