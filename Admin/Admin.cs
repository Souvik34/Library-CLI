using System;
using System.Collections.Generic;
using LibrarySystem.Application;  // Correct namespace for the User class

namespace LibrarySystem.Application
{
    public class Admin
    {
        private List<User> users;

        public Admin()
        {
            users = new List<User>();
        }

        // Admin authentication
        public bool AuthenticateAdmin(string username, string password)
        {
            // Simple hardcoded admin login for demonstration
            return username == "admin" && password == "admin123";
        }

        // Method to view all users and their borrowed books
        public void ViewAllUsersAndBooks()
        {
            Console.WriteLine("\n--- Users and Borrowed Books ---");
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.Username}");
                foreach (var book in user.BorrowedBooks)
                {
                    Console.WriteLine($"Book: {book.Title}, Issue Date: {book.IssueDate?.ToShortDateString()}, Return Date: {book.ReturnDate?.ToShortDateString()}, Reissue: {(book.CanBeReissued ? "Yes" : "No")}");
                }
                Console.WriteLine();
            }
        }

        // Method to add a user
        public void AddUser(string username, string password)
        {
            if (users.Exists(u => u.Username == username))
            {
                Console.WriteLine("User already exists.");
                return;
            }

            User newUser = new User(username, password);
            users.Add(newUser);
            Console.WriteLine("User added successfully.");
        }

        // Method to delete a user
        public void DeleteUser(string username)
        {
            var userToDelete = users.Find(u => u.Username == username);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                Console.WriteLine("User deleted successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // Method to view borrowed books of a specific user
        public void ViewUserBorrowedBooks(string username)
        {
            var user = users.Find(u => u.Username == username);
            if (user != null)
            {
                Console.WriteLine($"\n--- {user.Username}'s Borrowed Books ---");
                foreach (var book in user.BorrowedBooks)
                {
                    Console.WriteLine($"Book: {book.Title}, Issue Date: {book.IssueDate?.ToShortDateString()}, Return Date: {book.ReturnDate?.ToShortDateString()}, Reissue: {(book.CanBeReissued ? "Yes" : "No")}");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // Method to add a book to a user's borrowed list
        public void BorrowBookToUser(string username, Book book)
        {
            var user = users.Find(u => u.Username == username);
            if (user != null)
            {
                book.IssueDate = DateTime.Now;
                book.ReturnDate = book.IssueDate.Value.AddDays(7); // Set return date for 1 week
                user.BorrowedBooks.Add(book);
                Console.WriteLine($"Book '{book.Title}' borrowed by {user.Username}. Issue Date: {book.IssueDate?.ToShortDateString()}, Return Date: {book.ReturnDate?.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // Method to return a borrowed book
        public void ReturnBookFromUser(string username, Book book)
        {
            var user = users.Find(u => u.Username == username);
            if (user != null)
            {
                var borrowedBook = user.BorrowedBooks.Find(b => b.Title == book.Title);
                if (borrowedBook != null)
                {
                    user.BorrowedBooks.Remove(borrowedBook);
                    Console.WriteLine($"Book '{book.Title}' returned by {user.Username}.");
                }
                else
                {
                    Console.WriteLine("Book not found in user's borrowed list.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // Method to reissue a book if the return date has passed
        public void ReissueBook(string username, Book book)
        {
            var user = users.Find(u => u.Username == username);
            if (user != null)
            {
                var borrowedBook = user.BorrowedBooks.Find(b => b.Title == book.Title);
                if (borrowedBook != null && DateTime.Now > borrowedBook.ReturnDate)
                {
                    borrowedBook.ReturnDate = DateTime.Now.AddDays(7); // Reissue for another 7 days
                    borrowedBook.CanBeReissued = true;
                    Console.WriteLine($"Book '{book.Title}' has been reissued. New Return Date: {borrowedBook.ReturnDate?.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine("Book cannot be reissued.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}
