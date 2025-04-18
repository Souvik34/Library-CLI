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
                    throw new ArgumentException("Title cannot be empty.");
                _title = value;
            }
        }

        public string Author 
        { 
            get { return _author; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Author cannot be empty.");
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
                throw new InvalidOperationException("This book is already borrowed.");
            IsBorrowed = true;
        }

        // Return the book
        public void ReturnBook()
        {
            if (!IsBorrowed)
                throw new InvalidOperationException("This book is not borrowed.");
            IsBorrowed = false;
        }

     
    }
}
