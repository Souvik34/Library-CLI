using System;
using System.Collections.Generic;
using System.IO;

namespace LibrarySystem
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void LoadData()
        {
            // Load data from file if exists
            if (File.Exists("libraryData.txt"))
            {
                var lines = File.ReadAllLines("libraryData.txt");
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    var book = new Book(data[0], data[1], bool.Parse(data[2]));
                    books.Add(book);
                }
            }
        }

        public void SaveData()
        {
            var lines = new List<string>();
            foreach (var book in books)
            {
                lines.Add($"{book.Title},{book.Author},{book.IsBorrowed}");
            }
            File.WriteAllLines("libraryData.txt", lines);
        }

        public void AddBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Title and Author cannot be empty.");
                return;
            }

            books.Add(new Book(title, author));
            Console.WriteLine("Book added successfully.");
        }

        public void DeleteBook()
        {
            Console.Write("Enter book title to delete: ");
            string title = Console.ReadLine();
            var bookToRemove = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void ViewBooks()
        {
            Console.WriteLine("\n--- List of Books ---");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Borrowed: {(book.IsBorrowed ? "Yes" : "No")}");
            }
        }

        public void BorrowBook()
        {
            Console.Write("Enter book title to borrow: ");
            string title = Console.ReadLine();
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book != null)
            {
                book.BorrowBook();
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void ReturnBook()
        {
            Console.Write("Enter book title to return: ");
            string title = Console.ReadLine();
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book != null)
            {
                book.ReturnBook();
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
}
