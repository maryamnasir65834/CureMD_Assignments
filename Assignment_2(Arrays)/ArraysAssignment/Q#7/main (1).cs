using System;

class Program
{
    public static bool Armstrong_Number(int number)
    {
                                                        
        string number_String = number.ToString();           // Convert number to string for counting digits by it length
        int Num = number_String.Length;

        int sum = 0;
        foreach (char Character in number_String)
        {
            int value = Character - '0';                    // Convert char to int digit
            int cube_of_number = value * value * value;     // taking cube of the converted integer digit from character to int

            sum = sum + cube_of_number;                      // Add the cube of the digit to an already intilized variable sum
        }

        return sum == number;                                // Check if sum of cubes of digits equals the number if yes its an armstrong number otherwise no
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
