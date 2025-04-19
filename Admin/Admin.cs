using System;
using System.Linq;
using System.Collections.Generic;
// using Application;


namespace LibrarySystem.Application
{
    public class Admin
    {
        private string adminUsername = "admin";
        private string adminPassword = "admin123";
        private Library library;
        private List<User> users;

        public Admin(Library library)
        {
            this.library = library;
            this.users = UserStore.Users;
        }

        public void Login()
        {
            Console.Write("Enter admin username: ");
            string username = Console.ReadLine();
            Console.Write("Enter admin password: ");
            string password = Console.ReadLine();

            if (username != adminUsername || password != adminPassword)
            {
                Console.WriteLine("Access denied.");
                return;
            }

            Console.WriteLine("Welcome, Admin!");

            while (true)
            {
                Console.WriteLine("\n1. Add Book\n2. View All Books\n3. View All Users & Borrowed Books\n4. Logout");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter book author: ");
                        string author = Console.ReadLine();
                        library.AddBook(title, author);
                        Console.WriteLine("Book added.");
                        break;
                    case "2":
                        library.ViewBooks();
                        break;
                    case "3":
                        ViewUsers();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ViewUsers()
        {
            if (!users.Any())
            {
                Console.WriteLine("No users registered.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine($"\nUser: {user.Username}");
                if (!user.BorrowedBooks.Any())
                {
                    Console.WriteLine("  No books borrowed.");
                }
                else
                {
                    foreach (var book in user.BorrowedBooks)
                    {
                        Console.WriteLine($"  Title: {book.Title}, Issue: {book.IssueDate}, Return: {book.ReturnDate}, Reissue: {(book.IsReissued ? "Yes" : "No")}");
                    }
                }
            }
        }
    }
}
