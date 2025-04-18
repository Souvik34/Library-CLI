using System;

namespace LibrarySystem
{
    public class Book
    {
        private string _title;
        private string _author;

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Title cannot be empty.");
                    return;
                }
                _title = value;
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Author cannot be empty.");
                    return;
                }
                _author = value;
            }
        }

        public bool IsBorrowed { get; private set; }

        public Book(string title, string author, bool isBorrowed = false)
        {
            Title = title;
            Author = author;
            IsBorrowed = isBorrowed;
        }

        // Borrow the book
        public void BorrowBook()
        {
            if (IsBorrowed)
            {
                Console.WriteLine("This book is already borrowed.");
                return;
            }
            IsBorrowed = true;
            Console.WriteLine($"You have successfully borrowed '{Title}'.");
        }

        // Return the book
        public void ReturnBook()
        {
            if (!IsBorrowed)
            {
                Console.WriteLine("This book was not borrowed.");
                return;
            }
            IsBorrowed = false;
            Console.WriteLine($"You have successfully returned '{Title}'.");
        }
    }
}
