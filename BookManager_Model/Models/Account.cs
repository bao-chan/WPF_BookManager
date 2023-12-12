using System;
using System.Collections.Generic;

namespace BookManager_Model.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsActive { get; set; }
        public string? Role { get; set; }
    }
}
