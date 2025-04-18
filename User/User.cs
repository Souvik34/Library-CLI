using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class User
    {
        public string Username { get; }
        public string Password { get; }
        public List<Book> BorrowedBooks { get; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Invalid book.");
                return;
            }

            if (book.IsBorrowed)
            {
                Console.WriteLine("This book is already borrowed.");
                return;
            }

            book.Borrow();
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(string title)
        {
            var book = BorrowedBooks.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.Return();
                BorrowedBooks.Remove(book);
            }
            else
            {
                Console.WriteLine("You haven't borrowed this book.");
            }
        }

        public void ReissueBook(string title)
        {
            var book = BorrowedBooks.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.Reissue();
            }
            else
            {
                Console.WriteLine("You haven't borrowed this book.");
            }
        }

        public void ViewBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("No books borrowed.");
                return;
            }

            Console.WriteLine($"\nBorrowed books by {Username}:");
            foreach (var book in BorrowedBooks)
            {
                Console.WriteLine($"- {book.Title} by {book.Author}");
                Console.WriteLine($"  Issued: {book.IssueDate?.ToString("dd MMM yyyy")}");
                Console.WriteLine($"  Return by: {book.ReturnDate?.ToString("dd MMM yyyy")}");
                Console.WriteLine($"  Reissued: {(book.IsReissued ? "Yes" : "No")}\n");
            }
        }
    }
}
