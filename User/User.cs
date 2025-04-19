using System;
using System.Collections.Generic;
using System.Linq;
using Library_CLI_1;

namespace LibrarySystem.Application
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
            if (book == null || book.IsBorrowed)
            {
                Console.WriteLine("Book is not available.");
                return;
            }

            book.BorrowBook(Username);
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(string title)
        {
            var book = BorrowedBooks.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.ReturnBook();
                BorrowedBooks.Remove(book);
            }
            else
            {
                Console.WriteLine("Book not found in your borrowed list.");
            }
        }

        public void ViewBorrowedBooks()
        {
            if (!BorrowedBooks.Any())
            {
                Console.WriteLine("No books borrowed.");
                return;
            }

            foreach (var book in BorrowedBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Issue: {book.IssueDate}, Return: {book.ReturnDate}, Reissue: {(book.IsReissued ? "Yes" : "No")}");
            }
        }
    }
}
