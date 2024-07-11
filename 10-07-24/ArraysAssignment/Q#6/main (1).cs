using System;

class Program
{
    public static int Missing_Number(int[] number)
    {
        // Calculate the sum of first n natural numbers
        int Number = number.Length + 1;
        int Result = Number * (Number - 1) / 2;

        // Calculate the sum of elements in the array
        int sum_Of_Elements = 0;
        foreach (int num in number)
        {
            sum_Of_Elements += num;
        }

        // The missing number is the difference between totalSum and sum of array elements
        return Result - sum_Of_Elements;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter elements of the array (distinct numbers from 0 to n) separated by spaces:");
        string input = Console.ReadLine();
        int[] number = Array.ConvertAll(input.Split(' '), int.Parse);

        int missingNumber = Missing_Number(number);

        Console.WriteLine($"The missing number in the array is: {missingNumber}");
    }
}
