using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibrarySystem.Application
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
        public string BorrowedBy { get; set; } // User who borrowed the book
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReissued { get; set; } // Flag to check if the book was reissued after the return date

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsBorrowed = false;
            IsReissued = false;
        }

        // Method to borrow a book
        public void BorrowBook(string username)
        {
            if (IsBorrowed)
                throw new InvalidOperationException("This book is already borrowed.");
            IsBorrowed = true;
            BorrowedBy = username;
            IssueDate = DateTime.Now;
            ReturnDate = IssueDate.Value.AddDays(7); // Set return date to 7 days from issue date
        }

        // Method to return a book
        public void ReturnBook()
        {
            if (!IsBorrowed)
                throw new InvalidOperationException("This book is not borrowed.");
            IsBorrowed = false;
            if (DateTime.Now > ReturnDate.Value) // Check if the return date has passed
            {
                IsReissued = true; // Set to reissued if the book is returned after the due date
            }
            BorrowedBy = null;
            IssueDate = null;
            ReturnDate = null;
        }
    }

    public class Library
    {
        private List<Book> books;
        private List<User.User> users;

        public Library()
        {
            books = new List<Book>();
            users = new List<User.User>();
        }

        // Method to add a new book to the library
        public void AddBook(string title, string author)
        {
            books.Add(new Book(title, author));
            Console.WriteLine("Book added successfully.");
        }

        // Method to delete a book from the library
        public void DeleteBook(string title)
        {
            var book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Method to view all books in the library
        public void ViewBooks()
        {
            Console.WriteLine("\n--- List of Books ---");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Borrowed: {(book.IsBorrowed ? "Yes" : "No")}");
            }
        }

        // Method for a user to borrow a book
        public void BorrowBook(string title, string username)
        {
            var book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                try
                {
                    book.BorrowBook(username);
                    Console.WriteLine($"You have successfully borrowed '{book.Title}'.");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Method for a user to return a book
        public void ReturnBook(string title)
        {
            var book = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                try
                {
                    book.ReturnBook();
                    Console.WriteLine($"You have successfully returned '{book.Title}'.");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Method for viewing the borrowed books by users (Admin only)
        public void ViewBorrowedBooks()
        {
            Console.WriteLine("\n--- Borrowed Books ---");
            foreach (var book in books.Where(b => b.IsBorrowed))
            {
                Console.WriteLine($"Book: {book.Title}, Borrowed By: {book.BorrowedBy}, Issue Date: {book.IssueDate?.ToShortDateString()}, Return Date: {book.ReturnDate?.ToShortDateString()}, Reissued: {(book.IsReissued ? "Yes" : "No")}");
            }
        }

        // Method for registering a new user
        public void RegisterUser(string username, string password)
        {
            if (users.Any(u => u.Username == username))
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
                return;
            }

            var user = new User.User(username, password);
            users.Add(user);
            Console.WriteLine("User registered successfully.");
        }

        // Method for authenticating a user (simplified)
        public bool AuthenticateUser(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }
    }
}
