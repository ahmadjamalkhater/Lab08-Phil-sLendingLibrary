using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Library<Book> library = new Library<Book>();
        LoadBooks(library);

        UserInterface(library);
    }

    static void LoadBooks(Library<Book> library)
    {
        library.Add(new Book("Book in c# languge", "ahmad"));
        library.Add(new Book("Book in java languge", "jamal"));
        library.Add(new Book("Book in paython languge", "khater"));
    }

    static void UserInterface(Library<Book> library)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. View all Books");
            Console.WriteLine("2. Add a Book");
            Console.WriteLine("3. Borrow a Book");
            Console.WriteLine("4. Return a Book");
            Console.WriteLine("5. Search Books by Title");
            Console.WriteLine("6. Exit");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    ViewAllBooks(library);
                    break;
                case "2":
                    AddBook(library);
                    break;
                case "3":
                    BorrowBook(library);
                    break;
                case "4":
                    ReturnBook(library);
                    break;
                case "5":
                    SearchBooksByTitle(library);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void ViewAllBooks(Library<Book> library)
    {
        Console.WriteLine("All Books:");
        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
    }

    static void AddBook(Library<Book> library)
    {
        Console.WriteLine("Enter Book details:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();

        library.Add(new Book(title, author));
        Console.WriteLine("Book added successfully.");
    }

    static void BorrowBook(Library<Book> library)
    {
        Console.Write("Enter the title of the Book to borrow: ");
        string title = Console.ReadLine();

        Book book = library.Borrow(title);
        if (book != null)
        {
            Console.WriteLine($"Book '{book.Title}' borrowed successfully.");
        }
        else
        {
            Console.WriteLine("Book not found in the library.");
        }
    }

    static void ReturnBook(Library<Book> library)
    {
        Console.Write("Enter the title of the Book to return: ");
        string title = Console.ReadLine();

        Book book = new Book(title, "");
        library.Return(book);
        Console.WriteLine("Book returned to the library.");
    }

    static void SearchBooksByTitle(Library<Book> library)
    {
        Console.Write("Enter the title to search: ");
        string title = Console.ReadLine();

        List<Book> foundBooks = library.SearchByTitle(title);
        if (foundBooks.Count > 0)
        {
            Console.WriteLine($"Found {foundBooks.Count} book(s) with the title '{title}':");
            foreach (var book in foundBooks)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("No books found with the specified title.");
        }
    }
}
