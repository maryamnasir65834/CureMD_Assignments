using System;

class Program
{
    
    public static void MoveZerosToEnd(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return;                                 // If the array is empty or null, no operation needed
        }

        int count_non_zero = 0;                     // Initialize a count to keep track of non-zero elements

        
        for (int i = 0; i < array.Length; i++)      // Traverse through the array and move non-zero elements to the front
        {
            if (array[i] != 0)
            {
                array[count_non_zero++] = array[i]; // Move non-zero element to the front
            }
        }

       
        while (count_non_zero < array.Length)        // Fill the remaining positions with zeros
        {
            array[count_non_zero++] = 0;
        }
    }

    
    public static void PrintArray(int[] array)        // print the elements of an integer array
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

        
        string[] inputArray = input.Split(' ');        // Split the input string by spaces and convert it into an integer array
        int[] array = Array.ConvertAll(inputArray, int.Parse);

        Console.WriteLine("\nOriginal Array:");
        PrintArray(array);                              // Print original array

        MoveZerosToEnd(array);                          // Move zeros to the end

        Console.WriteLine("\nArray with Zeros Moved to End:");
        PrintArray(array);                              // Print modified array
    }
}
