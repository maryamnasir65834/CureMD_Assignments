using System;

class Program
{
    // Method to move zeros to the end of the array
  public static (int, int) First_and_second_largest(int[] A)
  {
      if (A.Length < 2)
      {
          // Handle case where array has fewer than 2 elements

          Console.WriteLine("Array does not contain enough distinct elements to determine                                   the first and second largest numbers.");
          return (0, 0); // Return default values or handle this case as needed
      }

      int first_largest = A[0];
      int second_largest = A[1];

      if (second_largest > first_largest)
      {
          // Swap values if necessary to ensure first_largest > second_largest

          int temporary = first_largest;
          first_largest = second_largest;
          second_largest = temporary;
      }

      // Iterate through the array to find the largest and second largest numbers
      for (int i = 2; i < A.Length; i++)
      {
          if (A[i] > first_largest)
          {
              second_largest = first_largest;
              first_largest = A[i];
          }
          else if (A[i] > second_largest)
          {
              second_largest = A[i];
          }
      }

      // Print the results
      Console.WriteLine($"First largest number is: {first_largest}");
      Console.WriteLine($"Second largest number is: {second_largest}");

      // Return a tuple containing the largest and second largest numbers
      return (first_largest, second_largest);
  }





    public static void Main(string[] args)
    {

      Console.WriteLine("Enter the numbers of the array separated by spaces:");
          string input = Console.ReadLine(); // Taking input from the user as a string

          string[] input_Array = input.Split(' '); // Splitting the input string into an array of                                                    strings
          int[] this_array = Array.ConvertAll(input_Array, int.Parse); // Converting the string                                                                          array to an integer array

          // Call the method to find the largest and second largest numbers
          var result = First_and_second_largest(this_array);
    }
}
