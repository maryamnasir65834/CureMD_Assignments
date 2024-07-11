using System;

class Program
{
    public static void Fibonacci(int number)
    {
        int first_term = 0, second_term = 1;

        Console.Write("Fibonacci Sequence up to " + number + " terms: ");

                                                                            // Print the first two terms
        Console.Write(first_term + " " + second_term + " ");

                                                                            
        for (int i = 3; i <= number; i++)                                   // Calculating and printing the rest of the sequence .Loop through the sequence starting from the third term up to and including the nth term (number)
        {                                                                   // Calculate the next term in the sequence by adding the previous two terms
            int next = first_term + second_term;                            // Print the next term followed by a space
            Console.Write(next + " ");                                      // Update the first_term to be the value of the current second_term
            first_term = second_term;                                       // Update the second_term to be the value of the calculated next term for the next iteration
            second_term = next;
        }
        Console.WriteLine();                                                // Move to the next line after printing the sequence
    }


public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of terms for the Fibonacci sequence:");
        int num = Convert.ToInt32(Console.ReadLine());                       // Read user input for number of terms

        if (num <= 0)
        {
            Console.WriteLine("Please enter a positive integer greater than zero.");
        }
        else
        {
            Fibonacci(num);                                                 // Print Fibonacci sequence up to n terms
        }
    }
}
