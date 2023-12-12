using System;
using System.Collections.Generic;

namespace BookManager_Model.Models
{
    public partial class Storage
    {
        public Storage()
        {
            BookInStorages = new HashSet<BookInStorage>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<BookInStorage> BookInStorages { get; set; }
    }
}
