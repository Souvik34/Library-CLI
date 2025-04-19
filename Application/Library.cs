using System;
using System.Collections.Generic;
using System.Linq;
using Library_CLI_1;

namespace LibrarySystem.Application
{
    public class Library
    {
        private List<Book> books;
        private List<User> users;

        public Library()
        {
            books = new List<Book>();
            users = UserStore.Users;
        }

        public void AddBook(string title, string author)
        {
            books.Add(new Book(title, author));
        }

        public void RegisterUser(string username, string password)
        {
            if (users.Any(u => u.Username == username))
            {
                Console.WriteLine("Username already exists.");
                return;
            }

            users.Add(new User(username, password));
        }

        public void LoginUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                Console.WriteLine("Invalid credentials.");
                return;
            }

            Console.WriteLine($"Welcome, {user.Username}!");

            while (true)
            {
                Console.WriteLine("\n1. View All Books\n2. Borrow Book\n3. Return Book\n4. View My Borrowed Books\n5. Logout");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewBooks();
                        break;
                    case "2":
                        Console.Write("Enter book title to borrow: ");
                        string borrowTitle = Console.ReadLine();
                        var bookToBorrow = books.FirstOrDefault(b => b.Title.Equals(borrowTitle, StringComparison.OrdinalIgnoreCase));
                        user.BorrowBook(bookToBorrow);
                        break;
                    case "3":
                        Console.Write("Enter book title to return: ");
                        string returnTitle = Console.ReadLine();
                        user.ReturnBook(returnTitle);
                        break;
                    case "4":
                        user.ViewBorrowedBooks();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public void ViewBooks()
        {
            foreach (var book in books)
            {
                string status = book.IsBorrowed ? $"Borrowed by {book.BorrowedBy}" : "Available";
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Status: {status}");
            }
        }

        public List<Book> GetBooks()
        {
            return books;
        }
    }
}
