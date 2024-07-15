using System;
using System.Collections.Generic;                                     // This namespace provides generic collection classes, such as lists, dictionaries, queues, and others.     


abstract class Book                                                   // Abstract Base Class                                         
{
    public string Title;                                              // Attributes of Book class
    public string Author;
    public string BookID;

    // Constructor
    public Book(string title, string author, string bookID)           // Constructor to initialize the attribute values
    {
        Title = title;
        Author = author;
        BookID = bookID;
    }


    public abstract void DisplayInfo();                                 // Abstract method to be overridden


    // Extra Book class methods 
    public virtual bool IsAvailable(List<Book> issuedBooks)
    {
        return !issuedBooks.Contains(this);                             //This method call checks if the current instance of the Book object(this) exists in the issuedBooks list.
    }


    public void DisplayAvailability(List<Book> issuedBooks)             // Method to display availability status of the book
    {
        if (IsAvailable(issuedBooks))
        {
            Console.WriteLine($"Book '{Title}' with ID '{BookID}' is available.");
        }
        else
        {
            Console.WriteLine($"Book '{Title}' with ID '{BookID}' is currently not available.");
        }
    }
}


class FictionBook : Book                                                // Derived Class FictionBook
{
    public string Genre;                                                // Extra added attribute


    public FictionBook(string title, string author, string bookID, string genre)     // Constructor to initialize the attribute values
        : base(title, author, bookID)
    {
        Genre = genre;
    }

    public override void DisplayInfo()                                  // Override DisplayInfo method. A subclass provides a specific implementation of a method that is already defined in its superclass 
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Book ID: {BookID}, Genre: {Genre}");
    }
}


class NonFictionBook : Book                                             // Derived Class FictionBook
{
    public string Subject;                                              // Extra added attribute

    public NonFictionBook(string title, string author, string bookID, string subject)     // Constructor to initialize the attribute values
        : base(title, author, bookID)
    {
        Subject = subject;
    }

    public override void DisplayInfo()                                  // Override DisplayInfo method. A subclass provides a specific implementation of a method that is already defined in its superclass 
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Book ID: {BookID}, Subject: {Subject}");
    }
}


class Person                                                             // Base Class Person
{
    public string Name;                                                  // Attributes for person class
    public int Age;
    public string PersonID;

    public bool IsRegistered;                                            // Attribute for Check added for is person already registered or not 


    public Person(string name, int age, string personID)                 // Constructor to initialize the attribute values
    {
        Name = name;
        Age = age;
        PersonID = personID;
        IsRegistered = false;                                           // Initially, a person is not registered
    }

    // Additional methods added to enhance person class
    public void UpdatePersonalInfo(string newName, int newAge)          // Updating previous info
    {
        Name = newName;
        Age = newAge;
        Console.WriteLine($"Personal information updated for {Name}. New age: {Age}");
    }
    public int YearsUntilAdulthood()
    {
        const int AdultAgeThreshold = 18;                               // Define the age threshold for adulthood
        if (Age < AdultAgeThreshold)
        {
            return AdultAgeThreshold - Age;                             // Calculate years remaining until adulthood
        }
        else
        {
            return 0;                                                   // Return 0 if already an adult
        }
    }

}


class Librarian : Person                                                // Derived Class Librarian inheriting from Person
{
    public string EmployeeID;                                           // Additional attribute added


    public Librarian(string name, int age, string personID, string employeeID)   // Constructor for initializing
        : base(name, age, personID)
    {
        EmployeeID = employeeID;
    }


    public void IssueBook(Book book, Person user)                        // Method specific to Librarian
    {
        Console.WriteLine($"Book '{book.Title}' issued to '{user.Name}' with User ID '{user.PersonID}' by Librarian '{Name}'.");
    }


    public void ReturnBook(Book book, Person user)                      // Method specific to Librarian
    {
        Console.WriteLine($"Book '{book.Title}' returned by '{user.Name}'with User ID '{user.PersonID}' to Librarian '{Name}'.");
    }
}

class Library                                                           // Library class (Main class)
{
    public string LibraryName;                                          // Attributes
    public string LibraryID;
    public List<Book> BooksInformation;                                 // A list to store information of books of library which is initially empty. 
    internal List<Book> issuedBooks;                                    //  A list to keep track of issued books from library to users. i have marked it as internal bcz It allows to hide implementation details that are not intended to be exposed outside of a specific assembly (DLL or executable).
    private Dictionary<string, List<string>> transactionHistory;        // Transaction history dictionary with PersonID as key (Dictionary<TKey, TValue>). I have used it here to let every user(key) assign its history(value) accordingly.
    public Librarian Librarian;                                         // A librarian attribute
    private Dictionary<string, Person> registeredUsers;                 // Dictionary to store registered users [ Assigns Key( " registered user id (personid)" to its value(name of person) by calling a person class object


    public Library(string libraryName, string libraryID, Librarian librarian)      // Constructor for intialization of values by object creation and assign it to their required attributes
    {
        LibraryName = libraryName;
        LibraryID = libraryID;
        Librarian = librarian;
        BooksInformation = new List<Book>();
        issuedBooks = new List<Book>();
        transactionHistory = new Dictionary<string, List<string>>();
        registeredUsers = new Dictionary<string, Person>();
    }


    public void AddBook(Book book)                                       // Method to add a book to the library (above list)
    {
        BooksInformation.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library '{LibraryName}'.");
    }


    public void RemoveBook(string bookID)                                // Method to remove a book from the library
    {
        Book bookToRemove = BooksInformation.Find(b => b.BookID == bookID);   // lambda expression>>> searches(Find method) for the first entry(book id) into the list and compares it to the bookid coming and add it to new variable book remove
        if (bookToRemove != null)
        {
            BooksInformation.Remove(bookToRemove);
            Console.WriteLine($"Book '{bookToRemove.Title}' removed from the library '{LibraryName}'.");
        }
        else
        {
            Console.WriteLine($"Book with ID '{bookID}' not found in the library '{LibraryName}'.");
        }
    }


    public void ViewBooks()                                             // Method to view all books in the library
    {
        Console.WriteLine($"Books in the library '{LibraryName}':");
        foreach (var book in BooksInformation)                          // iterates over every entry in the list
        {
            book.DisplayInfo();
        }
    }


    public void SearchBook(string title)                                 // Method to search for a book by title in the library
    {
        Book foundBook = BooksInformation.Find(b => b.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase));  // b.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase) is the condition being checked. It compares the Title of each book (b.Title) with the title value provided, using case-insensitive comparison.
        if (foundBook != null)
        {
            Console.WriteLine($"Book '{foundBook.Title}' found in the library '{LibraryName}':");
            foundBook.DisplayInfo();
        }
        else
        {
            Console.WriteLine($"Book with title '{title}' not found in the library '{LibraryName}'.");
        }
    }


    public void ListIssuedBooks()                                           // Method to list all issued books
    {
        Console.WriteLine($"Issued books in the library '{LibraryName}':");
        foreach (var book in issuedBooks)
        {
            book.DisplayInfo();
        }
    }


    public void IssueBook(Book book, Person user)                           // Method to issue a book to a user
    {
        if (!IsUserRegistered(user.PersonID))                               // (!) makes the true value of expression to null [CHECKING IF THE USER IS ALREADY REGISTERED TO ISSUEHIM/HER A BOOK]
        {
            Console.WriteLine($"User '{user.Name}' with ID '{user.PersonID}' is not registered. Please register first.");
            return;
        }

        Librarian.IssueBook(book, user);                                     // librarian will issue the book to user
        issuedBooks.Add(book);                                               // issued book list gets updated
        BooksInformation.Remove(book);                                       // Being removed from the list of library books ensuring its currently unavailable

        if (!transactionHistory.ContainsKey(user.PersonID))                  // Log transaction with user's PersonID
        {
            transactionHistory[user.PersonID] = new List<string>();          // If transactionHistory does not have an entry for user.PersonID, this line creates a new empty list and assigns it to that key. This initializes the user's transaction history.
        }
        transactionHistory[user.PersonID].Add($"Book '{book.Title}' issued to '{user.Name}' by Librarian '{Librarian.Name}'."); // Adds( Gnerates) the transactionhistory of user
    }


    public void ReturnBook(Book book, Person user)                            // Method to return a book from a user
    {

        if (issuedBooks.Contains(book))                                       // Check if the book was already in issued books list
        {

            if (transactionHistory.ContainsKey(user.PersonID) && transactionHistory[user.PersonID].Contains($"Book '{book.Title}' issued to '{user.Name}' by Librarian '{Librarian.Name}'."))    // Check if the book was issued to this specific user  ( checks if the coming userid is present as a key in the dictionary and the transaction history for issuence against that particular id exists in the  list
            {
                Librarian.ReturnBook(book, user);                              // if yes will call return book method
                issuedBooks.Remove(book);                                      // remove book from the issued book list
                BooksInformation.Add(book);                                    // and adds it to list of library books making it available to use now

                if (!transactionHistory.ContainsKey(user.PersonID))            // Log transaction with user's PersonID
                {
                    transactionHistory[user.PersonID] = new List<string>();
                }
                transactionHistory[user.PersonID].Add($"Book '{book.Title}' returned by '{user.Name}' to Librarian '{Librarian.Name}'.");
            }
            else
            {
                Console.WriteLine($"Book with ID '{book.BookID}' was not issued to user with ID '{user.PersonID}'.");
            }
        }
        else
        {
            Console.WriteLine($"Book with ID '{book.BookID}' is not currently issued."); // Will check if book is not issued(means no one can return)
        }
    }



    public void DisplayTransactionHistory(string personID)                      // Method to display transaction history for a specific user
    {
        if (transactionHistory.ContainsKey(personID))
        {
            Console.WriteLine($"Transaction History for Person ID '{personID}' in library '{LibraryName}':");
            foreach (var transaction in transactionHistory[personID])           // Displays every record against that user
            {
                Console.WriteLine(transaction);
            }
        }
        else
        {
            Console.WriteLine($"No transaction history found for Person ID '{personID}' in library '{LibraryName}'.");
        }
    }

    public void RegisterUser(Person user)                                       // Method for registering user
    {
        if (!registeredUsers.ContainsKey(user.PersonID))
        {
            registeredUsers[user.PersonID] = user;
            user.IsRegistered = true;
            Console.WriteLine($"User '{user.Name}' with ID '{user.PersonID}' registered successfully.");
        }
        else
        {
            Console.WriteLine($"User with ID '{user.PersonID}' is already registered.");
        }
    }

    public Person GetUserByID(string personID)
    {
        if (registeredUsers.ContainsKey(personID))                              // if id provided matches the key value pair in registered user
        {
            return registeredUsers[personID];                                   // return that id
        }
        return null;                                                            // Return null if user not found
    }

    public bool IsUserRegistered(string personID)
    {
        return registeredUsers.ContainsKey(personID);                           // returns yes if person id provided matches any key value pair in dictionary
    }
}

class Program
{
    static void Main(string[] args)
    {


        Librarian librarian = new Librarian("Alice", 30, "P001", "E001");      // Create a librarian (Intance of Librarian created)



        Library library = new Library("Central Library", "L001", librarian);   // Create a library (Instance of Library created)

        // Add some initial books to the library (Instances of books created as asked)

        library.AddBook(new FictionBook("The Lord of the Rings", "J.R.R. Tolkien", "F001", "Fantasy"));
        library.AddBook(new FictionBook("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", "F002", "Fantasy"));
        library.AddBook(new NonFictionBook("Sapiens: A Brief History of Humankind", "Yuval Noah Harari", "NF001", "Anthropology"));
        library.AddBook(new NonFictionBook("The Power of Habit", "Charles Duhigg", "NF002", "Psychology"));



        Person person = new Person("Hamna", 12, "101");                         // Instance of Person (Asked in part1)

        while (true)                                                            // Infinite loop alawys remain true unless specified a condition to stop in this case it is no 10
        {
            Console.WriteLine("\n******************** Library Management System ********************");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Remove a Book");
            Console.WriteLine("3. View All Books");
            Console.WriteLine("4. Search for a Book");
            Console.WriteLine("5. Issue a Book");
            Console.WriteLine("6. Return a Book");
            Console.WriteLine("7. List Issued Books");
            Console.WriteLine("8. Display Transaction History");
            Console.WriteLine("9. Register as a new user");
            Console.WriteLine("10. Exit");

            Console.Write("\nEnter your choice: ");

            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice))                   // Try parse converts string into int and return  a boolean, also value should be store in out expression after converting if conversion is successful(returns true) out value will be assigned to choice otherwsise default value 0
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            if (choice < 1 || choice > 10)                                        // check if choice should be a valid no 
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 10.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddBook(library);
                    break;
                case 2:
                    RemoveBook(library);
                    break;
                case 3:
                    library.ViewBooks();
                    break;
                case 4:
                    SearchBook(library);
                    break;
                case 5:
                    IssueBook(library);
                    break;
                case 6:
                    ReturnBook(library);
                    break;
                case 7:
                    library.ListIssuedBooks();
                    break;
                case 8:
                    DisplayTransactionHistory(library);
                    break;
                case 9:
                    RegisterUser(library);
                    break;
                case 10:
                    Console.WriteLine("Exiting Library Management System.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 10.");
                    break;
            }
        }
    }

    static void AddBook(Library library)
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();


        while (IsNumeric(title))                                          // Check if title is numeric
        {
            Console.WriteLine("Invalid input. Book title cannot contain only numeric characters.");
            Console.Write("Enter valid book title: ");
            title = Console.ReadLine();
        }

        Console.Write("Enter book author: ");
        string author = Console.ReadLine();


        while (!IsAlphabetic(author))                                     // Check if author contains only alphabetic characters
        {
            Console.WriteLine("Invalid input. Author name should only contain alphabetic characters.");
            Console.Write("Enter valid author name: ");
            author = Console.ReadLine();
        }

        Console.Write("Enter book ID: ");
        string bookID = Console.ReadLine();


        if (!int.TryParse(bookID, out _))                                  // Validate if bookID is numeric. underscore here is used for discard value. Discards are a feature in C# that allow you to indicate that you do not intend to use the value being output
        {
            Console.WriteLine("Invalid input. Book ID should be numeric.");
            return;
        }

        bool isFiction;

        while (true)                                                       // until user enters the valid input
        {
            Console.Write("Is it a fiction book? (Y/N): ");
            string fictionInput = Console.ReadLine().ToUpper();            // If user giving input in lower case
            if (fictionInput == "Y")
            {
                Console.Write("Enter genre: ");
                string genre = Console.ReadLine();


                while (!IsAlphabetic(genre))                               // Check if genre contains only alphabetic characters
                {
                    Console.WriteLine("Invalid input. Genre should only contain alphabetic characters.");
                    Console.Write("Enter valid genre: ");
                    genre = Console.ReadLine();
                }

                library.AddBook(new FictionBook(title, author, bookID, genre)); // Calls add book method
                break;
            }
            else if (fictionInput == "N")
            {
                Console.Write("Enter subject: ");
                string subject = Console.ReadLine().ToUpper();


                while (!IsAlphabetic(subject))                              // Check if subject contains only alphabetic characters
                {
                    Console.WriteLine("Invalid input. Subject should only contain alphabetic characters.");
                    Console.Write("Enter valid subject: ");
                    subject = Console.ReadLine();
                }

                library.AddBook(new NonFictionBook(title, author, bookID, subject));
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter Y or N.");
            }
        }
    }


    static void RemoveBook(Library library)
    {
        Console.Write("Enter book ID to remove: ");
        string bookID = Console.ReadLine();


        if (!int.TryParse(bookID, out int id))                              // Validate if bookID is numeric
        {
            Console.WriteLine("Invalid input. Book ID should be numeric.");
            return;
        }

        library.RemoveBook(bookID);
    }

    static void SearchBook(Library library)                                // calling search book method with the library object( cuz static method)
    {
        Console.Write("Enter book title to search: ");
        string title = Console.ReadLine();
        library.SearchBook(title);
    }

    static void IssueBook(Library library)
    {
        Console.Write("Enter book ID to issue: ");
        string bookID = Console.ReadLine();


        if (!int.TryParse(bookID, out int id))                              // Validate if bookID is numeric
        {
            Console.WriteLine("Invalid input. Book ID should be numeric.");
            return;
        }

        Console.Write("Enter user ID: ");
        string userID = Console.ReadLine();


        if (!int.TryParse(userID, out int userId))                          // Validate if userID is numeric
        {
            Console.WriteLine("Invalid input. User ID should be numeric.");
            return;
        }


        Person user = library.GetUserByID(userID);                          // Check if the user is registered
        if (user == null)
        {
            Console.WriteLine($"User with ID '{userID}' is not registered. Please register first.");
            return;
        }


        Book book = library.BooksInformation.Find(b => b.BookID == bookID);  // Find the book in the library

        if (book != null)
        {
            library.IssueBook(book, user);
        }
        else
        {
            Console.WriteLine($"Book with ID '{bookID}' not found in the library.");
        }
    }

    static void ReturnBook(Library library)                                 // returning book to library
    {
        Console.Write("Enter book ID to return: ");
        string bookID = Console.ReadLine();


        if (!int.TryParse(bookID, out int id))                               // Validate if bookID is numeric
        {
            Console.WriteLine("Invalid input. Book ID should be numeric.");
            return;
        }

        Console.Write("Enter user ID: ");
        string userID = Console.ReadLine();


        if (!int.TryParse(userID, out int userId))                           // Validate if userID is numeric
        {
            Console.WriteLine("Invalid input. User ID should be numeric.");
            return;
        }


        Person user = library.GetUserByID(userID);                          // Check if the user is registered
        if (user == null)
        {
            Console.WriteLine($"User with ID '{userID}' is not registered. Please register first.");
            return;
        }


        Book book = library.issuedBooks.Find(b => b.BookID == bookID);      // Find the book in the issued books list

        if (book != null)
        {

            if (library.issuedBooks.Contains(book))                          // Check if the book was issued to this user
            {
                library.ReturnBook(book, user);
            }
            else
            {
                Console.WriteLine($"Book with ID '{bookID}' was not issued to user with ID '{userID}'.");  // that book with particular book id is not present in issued book list to particular user id then what to return?
            }
        }
        else
        {
            Console.WriteLine($"Book with ID '{bookID}' not found among issued books in the library.");
        }
    }

    static void DisplayTransactionHistory(Library library)                   // Display Transaction function 
    {
        Console.Write("Enter user ID to display transaction history: ");
        string userID = Console.ReadLine();
        library.DisplayTransactionHistory(userID);
    }

    static void RegisterUser(Library library)                                // Register user function
    {
        Console.Write("Enter user name: ");
        string userName = Console.ReadLine();


        while (!IsAlphabetic(userName))                                      // Check if username contains only alphabetic characters
        {
            Console.WriteLine("Invalid input. User name should only contain alphabetic characters.");
            Console.Write("Enter valid user name: ");
            userName = Console.ReadLine();
        }

        Console.Write("Enter user ID: ");
        string userID = Console.ReadLine();


        if (!int.TryParse(userID, out _))                                   // Validate if userID is numeric
        {
            Console.WriteLine("Invalid input. User ID should be numeric.");
            return;
        }

        Person newUser = new Person(userName, 0, userID);                   // object made cuz its a non static method called by its object
        library.RegisterUser(newUser);
    }

    private static bool IsNumeric(string input)                             // Helper function to check if input is numeric or not
    {
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }


    private static bool IsAlphabetic(string input)                          // Helper method to check if a string contains only alphabetic characters
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }
}
