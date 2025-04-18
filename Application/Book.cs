using System;

namespace LibrarySystem
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public bool IsBorrowed { get; private set; }
        public DateTime? IssueDate { get; private set; }
        public DateTime? ReturnDate => IssueDate?.AddDays(7);
        public bool IsReissued { get; private set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            IsBorrowed = false;
            IssueDate = null;
            IsReissued = false;
        }

        public bool CanReissue()
        {
            return IsBorrowed && ReturnDate.HasValue && DateTime.Now > ReturnDate && !IsReissued;
        }

        public void Borrow()
        {
            if (IsBorrowed)
            {
                Console.WriteLine("This book is already borrowed.");
                return;
            }

            IsBorrowed = true;
            IssueDate = DateTime.Now;
            IsReissued = false;
            Console.WriteLine($"Book '{Title}' has been borrowed.");
        }

        public void Return()
        {
            if (!IsBorrowed)
            {
                Console.WriteLine("This book was not borrowed.");
                return;
            }

            IsBorrowed = false;
            IssueDate = null;
            IsReissued = false;
            Console.WriteLine($"Book '{Title}' has been returned.");
        }

        public void Reissue()
        {
            if (!CanReissue())
            {
                Console.WriteLine("Reissue not allowed. Either the return date hasn't passed or it's already reissued.");
                return;
            }

            IssueDate = DateTime.Now;
            IsReissued = true;
            Console.WriteLine($"Book '{Title}' has been reissued.");
        }
    }
}
