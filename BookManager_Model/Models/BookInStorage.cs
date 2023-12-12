using System;
using System.Collections.Generic;

namespace BookManager_Model.Models
{
    public partial class BookInStorage
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? StoreId { get; set; }
        public int? Quantity { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Storage? Store { get; set; }
    }
}
