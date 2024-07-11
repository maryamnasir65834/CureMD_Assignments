using System;

class Program
{
  public static (int, int) First_and_second_largest(int[] A) //
  {
      if (A.Length < 2)                         // Handle case where array has fewer than 2 elements no need to compare
        {
          Console.WriteLine("Array does not contain enough distinct elements to determine the first and second largest numbers.");
          return (0, 0);                        // Return default values or handle this case as needed
      }

      int first_largest = A[0];                 // Initializing first largest as first element of array
      int second_largest = A[1];                //Initializing second largest as second element of array

        if (second_largest > first_largest)
      {
          int temporary = first_largest;        // SwapING values if necessary to ensure first_largest > second_largest with the help of a temporary variable
            first_largest = second_largest;
          second_largest = temporary;
      }

     
      for (int i = 2; i < A.Length; i++)         // Iterate through the array to find the largest and second largest numbers
        {
          if (A[i] > first_largest)              // for now first largest is at 2nd position so we will start comparing from the third element and adjust accordingly
          {
              second_largest = first_largest;    
              first_largest = A[i];              // if rest of any number after two is greater than the first kargest we will swap it here too
          }
          else if (A[i] > second_largest)
          {
              second_largest = A[i];             // treating it same here too
          }
      }

     
        Console.WriteLine($"First largest number is: {first_largest}");            // Print the results
        Console.WriteLine($"Second largest number is: {second_largest}");

     
      return (first_largest, second_largest);                                      // Return a tuple containing the largest and second largest numbers, using tuple for ordered set of data getting first largest and 1st place and second at 2nd
    }





    public static void Main(string[] args)
    {

      Console.WriteLine("Enter the numbers of the array separated by spaces:");
          string input = Console.ReadLine();                                        // Taking input from the user as a string

          string[] input_Array = input.Split(' ');                                  // Splitting the input string into an array of strings

          int[] this_array = Array.ConvertAll(input_Array, int.Parse);              // Converting the string array to an integer array

          
          var result = First_and_second_largest(this_array);                        // Call the method to find the largest and second largest numbers
    }
}
