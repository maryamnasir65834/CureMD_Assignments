// Have the function FirstFactorial(num) take the num parameter being passed and return the factorial of it. For example if num= 4, then your program should return (4*3*2*1) = 24. For test cases, range will be between 1 and 18 and input will alawys be an integer
using System;
class MainClass
{
    public static int FirstFactorial(int num)
    {
        // Base case: factorial of 0 or 1 is 1
        if (num == 0 || num == 1)
        {
            return 1;
        }

        // Variable to store the factorial result
        int Factorial = 1;

        // Calculate factorial using a loop
        for (int i = 2; i <= num; i++)
        {
            Factorial = Factorial+ i;
        }

        return Factorial;
    }

    public static void Main()
    {
        // Example usage:
        int input = 4;
        Console.WriteLine($"Factorial of {input} is: {FirstFactorial(input)}"); // Output: 24
    }
}


