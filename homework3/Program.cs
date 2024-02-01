// See https://aka.ms/new-console-template for more information
                                                                                                                      using System; 
using System.Collections.Generic; 
 
// Book Class 
class Book
{
    // Properties 
    public string Title { get; set; }
    public Author Author { get; set; }
    public Category Category { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    // Constructors 
    public Book(string title, Author author, Category category, int year, decimal price)
    {
        Title = title;
        Author = author;
        Category = category;
        Year = year;
        Price = price;
    }
}

// Author Class 
class Author
{
    // Properties 
    public string Name { get; set; }
    public string Biography { get; set; }

    // Constructors 
    public Author(string name, string biography)
    {
        Name = name;
        Biography = biography;
    }
}

// Category Class (sealed) 
sealed class Category
{
    // Properties 
    public string CategoryName { get; set; }
    public string Description { get; set; }

    // Constructors 
    public Category(string categoryName, string description)
    {
        CategoryName = categoryName;
        Description = description;
    }
}

// LibraryManager Class (static) 
static class LibraryManager
{
    // Data storage 
    private static List<Book> books = new List<Book>();

    // Add a new book to the list 
    public static void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book added successfully!");
    }

    // Remove a book from the list by title 
    public static void RemoveBook(string title)
    {
        Book bookToRemove = books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Book removed successfully!");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // List all books in the library 
    public static void ListAllBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author.Name}, Category: {book.Category.CategoryName}, Year: {book.Year}, Price: {book.Price:C}");
        }
    }
}

// Main Program 
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. List All Books");
            Console.WriteLine("4. Exit");

            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    RemoveBook();
                    break;
                case 3:
                    ListAllBooks();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Helper method to add a book 
    static void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();

        Console.Write("Enter author name: ");
        string authorName = Console.ReadLine();

        Console.Write("Enter author biography: ");
        string biography = Console.ReadLine();

        Console.Write("Enter category name: ");
        string categoryName = Console.ReadLine();

        Console.Write("Enter category description: ");
        string categoryDescription = Console.ReadLine();

        Console.Write("Enter publication year: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Enter price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        // Create instances of Author, Category, and Book 
        Author author = new Author(authorName, biography);
        Category category = new Category(categoryName, categoryDescription);
        Book book = new Book(title, author, category, year, price);

        // Add the book using the LibraryManager 
        LibraryManager.AddBook(book);
    }

    // Helper method to remove a book 
    static void RemoveBook()
    {
        Console.Write("Enter the title of the book to remove: ");
        string titleToRemove = Console.ReadLine();

        // Remove the book using the LibraryManager 
        LibraryManager.RemoveBook(titleToRemove);
    }

    // Helper method to list all books 
    static void ListAllBooks()
    {
        // List all books using the LibraryManager 
        LibraryManager.ListAllBooks();
    }
}

