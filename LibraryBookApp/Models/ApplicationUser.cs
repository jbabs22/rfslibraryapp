using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LibraryBookApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Book> BorrowedBooks { get; set; } = new List<Book>();
    }
}

