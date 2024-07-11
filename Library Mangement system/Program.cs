using System;
using static System.Reflection.Metadata.BlobBuilder;

class Book
{
    public string Title;                                    // keeping attributes public if these attributes are called from outside the class itself it allows to do so. 
    public string Author;
    public int Book_ID;

    public Book (string title, string author, int book_ID)  // Creating constructor to initialize the attributes
    {
        Title = title;
        Author = author;
        Book_ID = book_ID;
    }

    public void display_info()                              // Method to display the books
    {
        Console.WriteLine($"Title = {Title}, Author = {Author}, Book_ID = {Book_ID}");
    }
}
class Person                                                // keeping attributes public if these attributes are called from outside the class itself it allows to do so. 
{
    public string Name;                                     
    public int Age;
    public int Person_ID;

    public Person (string name, int age, int person_ID)     // Creating constructor to initialize the attributes
    {
        Name = name;
        Age = age;
        Person_ID = person_ID;
    }
}

class Library
{
    public string Library_Name;                              // keeping attributes public if these attributes are called from outside the class itself it allows to do so.  
    public int Library_ID;
    private List<Book> Books_Information;                    // Creating list named book information


    public Library(string library_Name, int library_ID)      // Creating constructor to initialize the attributes
    {
        Library_Name = library_Name;
        Library_ID = library_ID;
        Books_Information = new List<Book>();                 // list initialized as empty list
    }

    public void AddBook(Book book)                            // Method for adding books in the list which was previously empty
                                                              // giving reference of book class which has all the books which we need to add
    {
        Books_Information.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }


    public void RemoveBook(int bookId)                        // Method for removing books from the list
    {
        Book bookToRemove = null;


        foreach (var book in Books_Information)              // Iterate through the Books collection to find the book with the specified
        {
            if (book.Book_ID == bookId)
            {
                bookToRemove = book;
                break;                                       // Exit the loop once the book is found
            }
        }


        if (bookToRemove != null)                            // Check if the book was found and remove it from list
        {
            Books_Information.Remove(bookToRemove);
            Console.WriteLine($"Book '{bookToRemove.Title}' removed from the library.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void ViewBooks()                                    // Method to view books in the list
    {
        if (Books_Information.Count == 0)
        {
            Console.WriteLine("No books in the library.");
        }
        else
        {
            Console.WriteLine("Books in the library:");
            foreach (var book in Books_Information)
            {
                book.display_info();
            }
        }
    }
}


    class Program
    {

        static void Main()
        {
            // Creating instances of Book
            Book book1 = new Book("Sience Book 11", "PTB", 1);
            Book book2 = new Book("Physics Book", "Punjab Text Book Board Lahore", 2);
            Book book3 = new Book("Finding Nemo", "Andrew Stanton", 3);
            Book book4 = new Book("Oliver Twist", "Charles Dickens", 4);

            // Creating an instance of Library
            Library library = new Library("City Library", 101);

            // Adding books to the library
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);

            // Viewing books in the library
            library.ViewBooks();

            // Removing a book from the library
            library.RemoveBook(1);

            // Viewing books in the library again
            library.ViewBooks();
        }
    }

