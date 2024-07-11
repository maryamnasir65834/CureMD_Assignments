using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string number = Console.ReadLine();          // Read the number string from the user

        char first_non_repeating_char = Find_First_Non_Repeating_Char(number); // Call method to find the first non-repeating character

        if (first_non_repeating_char != '\0')
        {
            Console.WriteLine($"First non-repeating character is: {first_non_repeating_char}"); // Print the first non-repeating character found
        }
        else
        {
            Console.WriteLine("No non-repeating characters found in the string."); // Print a message if no non-repeating character is found
        }
    }

    static char Find_First_Non_Repeating_Char(string number)
    {
                                                    // Create an array to count occurrences of each character (assuming ASCII characters)
        int[] charCount = new int[256];             // Size 256 to accommodate all possible ASCII characters

                                                    // Count occurrences of each character in the number string
        foreach (char c in number)
        {
            charCount[c]++;                         // Increment the count for character c
        }

                                                    // Find the first non-repeating character in the number string
        foreach (char c in number)
        {
            if (charCount[c] == 1)                  // Check if the count of character c is 1 (indicating it is non-repeating)
            {
                return c;                           // Return the first non-repeating character found
            }
        }

        return '\0';                                // Return null character if no non-repeating character is found
    }
}
