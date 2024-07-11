using System;

class Program
{
    // Method to move zeros to the end of the array
    public static void MoveZerosToEnd(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return; // If the array is empty or null, no operation needed
        }

        int countNonZero = 0; // Initialize a count to keep track of non-zero elements

        // Traverse through the array and move non-zero elements to the front
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != 0)
            {
                array[countNonZero++] = array[i]; // Move non-zero element to the front
            }
        }

        // Fill the remaining positions with zeros
        while (countNonZero < array.Length)
        {
            array[countNonZero++] = 0;
        }
    }

    // Utility method to print the elements of an integer array
    public static void PrintArray(int[] array)
    {
        foreach (var num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the elements of the array separated by spaces:");
        string input = Console.ReadLine(); // Read user input

        // Split the input string by spaces and convert it into an integer array
        string[] inputArray = input.Split(' ');
        int[] array = Array.ConvertAll(inputArray, int.Parse);

        Console.WriteLine("\nOriginal Array:");
        PrintArray(array); // Print original array

        MoveZerosToEnd(array); // Move zeros to the end

        Console.WriteLine("\nArray with Zeros Moved to End:");
        PrintArray(array); // Print modified array
    }
}
