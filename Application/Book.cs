namespace LibrarySystem
{
    public class Book
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public bool IsBorrowed { get; set; }

        public override string ToString()
        {
            return $"[ {(IsBorrowed ? "Borrowed" : "Available")} ] Title: {Title}, Author: {Author}";
        }
    }
}
