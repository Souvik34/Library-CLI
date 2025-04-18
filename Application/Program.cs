using System;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new();
            library.LoadData();
            bool running = true;

            Console.WriteLine("Welcome to the Library System!");

            while (running)
            {
                Console.Write("Enter your role (admin/user): ");
                string role = Console.ReadLine()?.ToLower();

                if (role == "admin")
                {
                    Console.WriteLine("\n--- Admin Menu ---");
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. Delete Book");
                    Console.WriteLine("3. View All Books");
                    Console.WriteLine("4. Save Data");
                    Console.WriteLine("5. Exit");

                    string? choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": library.AddBook(); break;
                        case "2": library.DeleteBook(); break;
                        case "3": library.ViewBooks(); break;
                        case "4": library.SaveData(); break;
                        case "5": running = false; break;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                else if (role == "user")
                {
                    Console.WriteLine("\n--- User Menu ---");
                    Console.WriteLine("1. View Books");
                    Console.WriteLine("2. Borrow Book");
                    Console.WriteLine("3. Return Book");
                    Console.WriteLine("4. Exit");

                    string? choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": library.ViewBooks(); break;
                        case "2": library.BorrowBook(); break;
                        case "3": library.ReturnBook(); break;
                        case "4": running = false; break;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid role.");
                    running = false;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
