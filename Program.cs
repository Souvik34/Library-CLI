using System;
using LibrarySystem.Application;

class Program
{
    static void Main(string[] args)
    {
        var library = new Library();
        var admin = new Admin(library);

        while (true)
        {
            Console.WriteLine("\n📚 Library Management System");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. Register User");
            Console.WriteLine("3. User Login");
            Console.WriteLine("4. Exit");
            Console.Write("Select option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    admin.Login();
                    break;
                case "2":
                    Console.Write("Choose username: ");
                    string uname = Console.ReadLine();
                    Console.Write("Choose password: ");
                    string pass = Console.ReadLine();
                    library.RegisterUser(uname, pass);
                    break;
                case "3":
                    library.LoginUser();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
