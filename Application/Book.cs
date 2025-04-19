using System;

namespace Library_CLI_1
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
        public string? BorrowedBy { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReissued { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsBorrowed = false;
            BorrowedBy = null;
            IssueDate = null;
            ReturnDate = null;
            IsReissued = false;
        }

        public void BorrowBook(string username)
        {
            if (IsBorrowed)
            {
                Console.WriteLine("Book is already borrowed.");
                return;
            }

            IsBorrowed = true;
            BorrowedBy = username;
            IssueDate = DateTime.Now;
            ReturnDate = IssueDate.Value.AddDays(7);
            IsReissued = false;
            Console.WriteLine($"Book borrowed successfully by {username}. Return by {ReturnDate.Value.ToShortDateString()}.");
        }

        public void ReturnBook()
        {
            if (!IsBorrowed)
            {
                Console.WriteLine("This book is not currently borrowed.");
                return;
            }

            IsBorrowed = false;
            BorrowedBy = null;
            IssueDate = null;
            ReturnDate = null;
            IsReissued = false;
            Console.WriteLine("Book returned successfully.");
        }

        public void ReissueBook()
        {
            if (!IsBorrowed)
            {
                Console.WriteLine("Cannot reissue a book that is not borrowed.");
                return;
            }

            if (IsReissued)
            {
                Console.WriteLine("Book has already been reissued once. Cannot reissue again.");
                return;
            }

            IssueDate = DateTime.Now;
            ReturnDate = IssueDate.Value.AddDays(7);
            IsReissued = true;
            Console.WriteLine($"Book reissued. New return date: {ReturnDate.Value.ToShortDateString()}.");
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Title: {Title} | Author: {Author} | Borrowed: {IsBorrowed}");

            if (IsBorrowed)
            {
                Console.WriteLine($"Borrowed By: {BorrowedBy} | Issue Date: {IssueDate?.ToShortDateString()} | Return Date: {ReturnDate?.ToShortDateString()} | Reissued: {IsReissued}");
            }
        }
    }
}
