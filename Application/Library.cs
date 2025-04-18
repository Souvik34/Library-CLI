using System;
using System.Collections.Generic;
using System.IO;

namespace LibrarySystem
{
    public class Library
    {
        private List<Book> books = new();
        private const string FilePath = "library.txt";

        public void LoadData()
        {
            if (File.Exists(FilePath))
            {
                foreach (var line in File.ReadAllLines(FilePath))
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        books.Add(new Book
                        {
                            Title = parts[0],
                            Author = parts[1],
                            IsBorrowed = bool.Parse(parts[2])
                        });
                    }
                }
            }
        }

        public void SaveData()
        {
            using StreamWriter sw = new(FilePath);
            foreach (var b in books)
                sw.WriteLine($"{b.Title}|{b.Author}|{b.IsBorrowed}");
        }

        public void AddBook()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine() ?? "";
            Console.Write("Enter author: ");
            string author = Console.ReadLine() ?? "";

            books.Add(new Book { Title = title, Author = author });
            Console.WriteLine("Book added.");
        }

        public void DeleteBook()
        {
            Console.Write("Enter title to delete: ");
            string title = Console.ReadLine() ?? "";
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book deleted.");
            }
            else Console.WriteLine("Book not found.");
        }

        public void ViewBooks()
        {
            if (books.Count == 0)
                Console.WriteLine("No books available.");
            else
                foreach (var book in books)
                    Console.WriteLine(book);
        }

        public void BorrowBook()
        {
            Console.Write("Enter title to borrow: ");
            string title = Console.ReadLine() ?? "";
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book != null && !book.IsBorrowed)
            {
                book.IsBorrowed = true;
                Console.WriteLine("Book borrowed.");
            }
            else if (book == null)
            {
                Console.WriteLine("Book not found.");
            }
            else
            {
                Console.WriteLine("Book is already borrowed.");
            }
        }

        public void ReturnBook()
        {
            Console.Write("Enter title to return: ");
            string title = Console.ReadLine() ?? "";
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book != null && book.IsBorrowed)
            {
                book.IsBorrowed = false;
                Console.WriteLine("Book returned.");
            }
            else if (book == null)
            {
                Console.WriteLine("Book not found.");
            }
            else
            {
                Console.WriteLine("Book wasn't borrowed.");
            }
        }
    }
}
