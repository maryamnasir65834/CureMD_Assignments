using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter N: ");
        int N = Convert.ToInt32(Console.ReadLine());            // Read the number of integers

        Console.WriteLine($"Enter {N} values separated by spaces:");
        string input = Console.ReadLine();                      // Read input values as a single string

        string[] valueStrings = input.Split(' ');               // Split the input string into individual values
        int[] values = new int[N];                              // Create an array to store parsed integers

                                                                // Convert each string value to integer and store in the array
        for (int i = 0; i < N; i++)
        {
            values[i] = Convert.ToInt32(valueStrings[i]);
        }

        int positive_number_Count = 0;
        int negative_number_Count = 0;
        int total = 0;

   
        foreach (int number in values)                          // Loop through each integer 'number' in the array 'values'
        {
            if (number > 0)                                     // Check if the current number is greater than zero
            {
                positive_number_Count++;                        // Increment the count of positive numbers
            }
            else if (number < 0)                                // If the current number is less than zero
            {
                negative_number_Count++;                        // Increment the count of negative numbers
            }

            total += number;                                    // Add the current number to the 'total' sum
        }


                                                                // Calculate the average
        double average = (double)total / N;

                                                                // Output the results
        Console.WriteLine($"The number of positive numbers: {positive_number_Count}");
        Console.WriteLine($"The number of negative numbers: {negative_number_Count}");
        Console.WriteLine($"Total is: {total}");
        Console.WriteLine($"Average is: {average}");
    }
}
