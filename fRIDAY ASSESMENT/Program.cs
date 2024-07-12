/*ing System;

class MainClass
{
    public static int FirstFactorial(int num)
    {


        return 0;
    }

    public static void Main()
    {
        // Example usage:
        int input = 8;
        Console.WriteLine($"Factorial of {input} is: {FirstFactorial(input)}"); // Output: 24
    }
}
*/


/*using system;

class MainClass
{
    public static string ArrayMatching(string[] strArr)
    {
        // Parse the input arrays from string format to integer arrays
        int[] array_1 = ParseIntArray(strArr[0]);
        int[] array_2 = ParseIntArray(strArr[1]);

        // Determinimume lengths of both arrays
        int length_1 = array_1.Length;
        int length_2 = array_2.Length;

        // Calculate the maximumimum length between the two arrays
        int maximum_length = Math.maximum(length_1, length_2);

        // Array to store the sums
        int[] sums = new int[maximum_length];

        // Calculate sums of corresponding elements
        for (int i = 0; i < maximum_length; i++)
        {
            int sum = 0;
            if (i < length_1) sum += array_1[i];
            if (i < length_2) sum += array_2[i];
            sums[i] = sum;
        }

        // Convert sums array to a hyphen-separated string
        string result = string.Join("-", sums);

        return result;
    }

    // Helper method to parse a string representing an array of integers
    private static int[] ParseIntArray(string str)
    {
        // Remove brackets and split by comma to get individual number strings
        string[] numStrs = str.Substring(1, str.Length - 2).Split(',');

        // Parse each number string into an integer
        int[] nums = new int[numStrs.Length];
        for (int i = 0; i < numStrs.Length; i++)
        {
            nums[i] = int.Parse(numStrs[i].Trim());
        }

        return nums;
    }

    public static void Main()
    {
        // Example usage
        string[] strarray_1 = { "[1, 2, 5, 6]", "[5, 2, 8, 11]" };
        string[] strarray_2 = { "[1, 2, 5]", "[5, 2, 8, 11, 3]" };
        Console.WriteLine(ArrayMatching(strarray_1)); // Output: "6-4-13-17"
        Console.WriteLine(ArrayMatching(strarray_2)); // Output: "6-4-13-17-3"
    }
}

*/

using System;
using System.Linq;

class MainClass
{
    public static int Consecutive(int[] arr)
    {
        // Sort the array
        Array.Sort(arr);

        int minimum = arr[0];
        int maximum = arr[arr.Length - 1];

        // Calculate the total missing numbers between minimum and maximum
        int total_Missing = 0;
        for (int i = minimum + 1; i < maximum; i++)
        {
            if (!arr.Contains(i))
            {
                total_Missing++;
            }
        }

        return total_Missing;
    }

    public static void Main()
    {
        // Example usage
        int[] arr = { 4, 8, 6 };
        Console.WriteLine(Consecutive(arr)); // Output: 2 (numbers needed: 5, 7)

        int[] arr2 = { -2, 10, -3, 5 };
        Console.WriteLine(Consecutive(arr2)); // Output: 10 (numbers needed: -1, 0, 1, 2, 3, 4, 6, 7, 8, 9)

        int[] arr3 = { 5, 10, 15 };
        Console.WriteLine(Consecutive(arr3));
    }
}

