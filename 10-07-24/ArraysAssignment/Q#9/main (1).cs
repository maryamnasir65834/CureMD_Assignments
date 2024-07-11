using System;

class Program
{
    public static void Fibonacci(int number)
    {
        int first_term = 0, second_term = 1;

        Console.Write("Fibonacci Sequence up to " + number + " terms: ");

        // Print the first two terms
        Console.Write(first_term + " " + second_term + " ");

        // Calculate and print the rest of the sequence
        for (int i = 3; i <= number; i++)
        {
            int next = first_term + second_term;
            Console.Write(next + " ");
            first_term = second_term;
            second_term = next;
        }
        Console.WriteLine(); // Move to the next line after printing the sequence
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of terms for the Fibonacci sequence:");
        int num = Convert.ToInt32(Console.ReadLine()); // Read user input for number of terms

        if (num <= 0)
        {
            Console.WriteLine("Please enter a positive integer greater than zero.");
        }
        else
        {
            Fibonacci(num); // Print Fibonacci sequence up to n terms
        }
    }
}
