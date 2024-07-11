using System;

class Program
{
  

  public static int[] Remove_Duplicates(int[] array)
    {
      if (array == null || array.Length < 2)    // checking if array has no or 1 element so it is already a sorted array.
      {
        return array;
      }
      Array.Sort(array);                        // sorting array to keep elments in an order

      int i = 0;                                // keeping track of index(position) of different elements and move forward with them to find unique elements

      for ( int j = 1; j < array.Length; j++)   // iterating through array to find unique elements while comparing with the i's value
      {
        if (array[j] != array[i])               // comparing elements of specified indices if they are not equal then we have a unique element olaced here                                                      element otherwise we move forward with the                                                     i's index
        {
          i++;
          array[i] = array[j];                  // replacing value
        }

      }
      int[] new_array = new int[i + 1];        // creating new array with the size of unique elements

      Array.Copy(array, new_array, i + 1);     // copying elements in new array

      return new_array;                        // returing a new array with no duplicates
    }





    public static void Main(string[] args)
    {

      Console.WriteLine("Enter the number of elements in the array containing duplicates seperated by spaces: ");  
      string user_input = Console.ReadLine();                       // taking input from the user in string

      string[] user_input_array = user_input.Split(' ');            // spliting the string input and  putting into an array(variable)

      int[] array = Array.ConvertAll(user_input_array , int.Parse); // converting string array  to int array using this                                                                        function

      int[] new_array = Remove_Duplicates(array);                   // calling function

      Console.WriteLine("New Array without duplicates:");
      foreach (var digit in new_array)                              //  iterating through new  array and printing each                                                                       element seperated by                                                                          spaces
      {
          Console.Write(digit + " ");
      }
    }
}
