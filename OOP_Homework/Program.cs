public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, string category, int year, double price)
    {
        Title = title;
        Author = author;
        Category = category;
        Year = year;
        Price = price;
    }
}

public sealed class Category
{
    public string CategoryName { get; set; }
    public string Description { get; set; }

    public Category(string categoryName, string description)
    {
        CategoryName = categoryName;
        Description = description;
    }
}

public static class LibraryManager
{
    private static List<Book> books = new List<Book>();

    public static void AddBook(Book book)
    {
        books.Add(book);
    }

    public static void RemoveBook(string title)
    {
        books.RemoveAll(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public static void ListAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Category: {book.Category}, Year: {book.Year}, Price: {book.Price}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Library Management System!");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. List All Books");
            Console.WriteLine("4. Quit");

            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("How many books do you want to add? ");
                    int count;
                    try
                    {
                        count = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < count; i++)
                        {
                            bool inputError = false; 

                            Console.WriteLine($"Enter details for Book {i + 1}:");
                            Console.Write("Title: ");
                            string title = Console.ReadLine();

                            Console.Write("Author: ");
                            string author = Console.ReadLine();

                            Console.Write("Category: ");
                            string category = Console.ReadLine();

                            int year;
                            double price;
                            try
                            {
                                Console.Write("Year: ");
                                year = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Price: ");
                                price = Convert.ToDouble(Console.ReadLine());

                                Book newBook = new Book(title, author, category, year, price);
                                LibraryManager.AddBook(newBook);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input for year or price. Please try again.");
                                inputError = true;
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine($"Unexpected error: {exception.Message}");
                                inputError = true;
                            }

                            if (inputError)
                            {
                                i--;
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input for book count.");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"Unexpected error: {exception.Message}");
                    }
                    finally
                    {
                        Console.WriteLine("Returning to menu...");
                    }
                    break;

                case "2":
                    Console.Write("Enter the title of the book you want to remove: ");
                    string titleToRemove = Console.ReadLine();
                    LibraryManager.RemoveBook(titleToRemove);
                    break;

                case "3":
                    LibraryManager.ListAllBooks();
                    break;

                case "4":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
