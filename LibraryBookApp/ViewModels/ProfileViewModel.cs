using System.Collections.Generic;
using LibraryBookApp.Models;

namespace LibraryBookApp.ViewModels
{
    public class ProfileViewModel
    {
        // Default values to fix nullability warning
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
    }
}