using System;

class Program
{
    public static bool Armstrong_Number(int number)
    {
        // Convert number to string to count digits
        string number_String = number.ToString();
        int Num = number_String.Length;

        int sum = 0;
        foreach (char Character in number_String)
        {
            int value = Character - '0'; // Convert char to int digit
            int cube_of_number = value * value * value;

            sum += cube_of_number;  // Add the cube of the digit
        }

        return sum == number; // Check if sum of cubes of digits equals the number
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number to check if it is an Armstrong number:");
        int number = int.Parse(Console.ReadLine());

        if (Armstrong_Number(number))
        {
            Console.WriteLine($"{number} is an Armstrong number.");
        }
        else
        {
            Console.WriteLine($"{number} is not an Armstrong number.");
        }
    }
}
