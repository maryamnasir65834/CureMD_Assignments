﻿
using System;

class Program
{



    //***** QUESTION # 3 (Checking LEAP YEAR) *****




    static void LEAP_YEAR(int year, int no_of_days)
    {


        if (no_of_days == 366)
        {
            Console.WriteLine("This is a Leap Year:" + year);
        }
        else if (no_of_days == 365)
        {
            Console.WriteLine("This year is not a Leap Year:" + year);
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }

    }



    //***** QUESTION # 4 (DISTANCE CONVERSION) ******




    static double Distance_Conversion(double Km_per_hour)
    {
        double Miles_per_hour = Km_per_hour * 0.621371;
        Console.WriteLine("Converted speed is:" + Miles_per_hour);
        return Miles_per_hour;
    }



    //***** QUESTION # 5 (CHECKING BUZZ NUMBER) ******



    static void CHECK_BUZZ_NUMBER(int num)
    {
        if (num % 7 == 0 || num % 10 == 7)
        {
            Console.WriteLine("Given Number is a BUZZ number:" + num);
        }
        else
        {
            Console.WriteLine("Given Number is not a BUZZ number:" + num);
        }
    }



    //***** QUESTION # 6 (PRINTING TABLE) ******




    static void MULTIPLICATION_TABLE(int table_digit)
    {
        for (int i = 1; i < 11; i++)
        {
            string Table = table_digit + "x" + i + "=" + (table_digit * i);
            Console.WriteLine(Table);
        }

    }



    //***** QUESTION # 7 (FACTORIAL) ******
    //using Recursion cuz it's easy to use



    static int FACTORIAL(int Factorial_digit)
    {
        if (Factorial_digit == 0 || Factorial_digit == 1)
        {
            return 1;
        }
        else
        {
            int Factorial = Factorial_digit * FACTORIAL(Factorial_digit - 1);
            Console.WriteLine("Factorial of number is:" + Factorial);
            return Factorial; // 7!= 7*6! then it will calculate 6! then it will calculate 5! then it will calculate 4! then it will calculate 3! then it will calculate 2! then it will calculate 1! then it will calculate 0! now it will return 1 and it will go back to the previous step and it will calculate the factorial of the previous number and build upwards.
        }
    }



    //***** QUESTION # 8 (CHECKING PRIME NUMBER) ******



    public static bool CHECK_PRIME_NUMBER(int digit)
    {
        if (digit <= 1)
        {
            Console.WriteLine("Given number is not a prime number:" + digit);
            return false;
        }
        for (int i = 2; i <= (digit - 1); i++) // since 1 and number itself makes number prime number, so checking for not prime requires it to be omitted
        {
            if (digit % i == 0)
            {
                Console.WriteLine("Given Number is not a prime number:" + digit);
                return false;
            }
        }
        Console.WriteLine("Given Number is a prime number:" + digit);
        return true; // statement is out of this bcz it needs to be executed ONLY IF it didnt find any divisor, placing it inside the loopin else block will immediately moves it to else and print its not a prime number, if it didnt find any divisor in first iteration, will cause to loose checking the remaining ones
    }



    //***** QUESTION # 9 (TYPES OF TRAINGLE) ******



    static void TYPE_OF_TRAINGLE(int len1, int len2, int len3)
    {
        if (len1 == len2 && len2 == len3)
        {
            Console.WriteLine("Traingle is a Quadilateral traingle");
        }
        else if (len1 == len2 && len2 != len3)
        {
            Console.WriteLine("Traingle is a Isoceles traingle");
        }
        else
        {
            Console.WriteLine("Traingle is a Scalene traingle");
        }
    }



    //***** QUESTION # 10 (PATTERN PRNTING) ******



    static void PATTERN_PRNTING(int star)
    {
        for (int i = 1; i <= star; i++)
        {
            Console.WriteLine(new String('*', i)); // this string variable is holding no of counts of each iteration and it will print the pattern.
        }

    }

    

    //***** QUESTION # 11 (PATTERN PRNTING) ******


    static bool CHECK_PALINDROME_NUMBER(int palindrome_number)
    {
        int input = palindrome_number;
        int reversed_number = 0; 
        while(palindrome_number>0)
        {
            int new_number = palindrome_number % 10; // dividing the palindrome number by 10 to calculate the remainder(which will be the last digit of number and will act as a first number of reversed digit)
            reversed_number = reversed_number * 10 + new_number;//adding new_number i.e the remainder of palindrome number to reversed number which is initialzed at 0 with fairst iterationa and multiplying it with 10 will
                                                                // shift digits to one place ahead i.e 10th position then 100th position and so on... aftyer that remainder at each iteration is added
            palindrome_number /= 10; // removing very last digit at each iteration and makes it reduced to 0


            Console.WriteLine("The New Number here is:"+ new_number);
            Console.WriteLine("The Reverrsed Number here is:" + reversed_number);
            Console.WriteLine("The Palindrome Number here is:" + palindrome_number);

        }
        return input == reversed_number;
    }


    // ******    MAIN FUNCTION    ******


    static void Main()
    {
        

        //**** QUESTION # 1 (SUMMING TWO NUMBERS) ***



        int A, B, C; // Initializing 3 variables

        Console.Write("Enter First Number:");
        A = int.Parse(Console.ReadLine());

        Console.Write("Enter Second Number:");
        B = int.Parse(Console.ReadLine());

        C = A + B;

        Console.WriteLine("Sum of two Numbers = " + C);




        //***** QUESTION # 2 (EVEN NUMBERS *******)


        int Number = 1;
        while (Number <= 100)
        {
            if (Number % 2 == 0)
            {
                Console.WriteLine("Even Numbers are :" + Number);
            }
            else
            {
                Number = Number + 1; // increments in terms of odd number cuz continue statement will make the code get out of the loop(so rest of the code will be ignored i.e incremental statement so i am providing it here) and start  with next iteration.

                continue; // if the current number is an odd number, it skips the iteration while loop continues with the next iteration 
            }
            Number = Number + 1;

        }



        //**** Q # 3 (REMAINING PART) *****


        Console.WriteLine("Enter the year:");
        int year = int.Parse(Console.ReadLine()); // take input i.e year from the user

        Console.WriteLine("Enter the number of days (365 or 366):");
        int no_of_days = int.Parse(Console.ReadLine()); // Input number of days from the user, using parse bcz the console.readline will always return string but we need integer so we are using parse to convert it into integer.

        LEAP_YEAR(year, no_of_days); // callingfunction



        //***** QUESTION # 4 (REMAINING PART) *****


        Console.WriteLine("Enter speed in kilometers per hour:");
        double Km_per_hour = double.Parse(Console.ReadLine()); // Input speed from the user (same logic of parse here)

        Distance_Conversion(Km_per_hour);


        //***** QUESTION # 5 (REMAINING PART) *****

        Console.WriteLine("Enter the Number:");
        int num = int.Parse(Console.ReadLine());
        CHECK_BUZZ_NUMBER(num);


        //***** QUESTION # 6 (REMAINING PART) *****

        Console.WriteLine("Enter the Table digit:");
        int table_digit = int.Parse(Console.ReadLine());
        MULTIPLICATION_TABLE(table_digit);


        //***** QUESTION # 7 (REMAINING PART) *****

        Console.WriteLine("Enter the Factorial digit:");
        int Factorial_digit = int.Parse(Console.ReadLine());
        FACTORIAL(Factorial_digit);


        //***** QUESTION # 8 (REMAINING PART) *****

        Console.WriteLine("Enter the digit:");
        int digit = int.Parse(Console.ReadLine());
        CHECK_PRIME_NUMBER(digit);


        //***** QUESTION # 9 (REMAINING PART) *****

        Console.WriteLine("Enter first side length:");
        int len1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second side length:");
        int len2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third side length:");
        int len3 = int.Parse(Console.ReadLine());

        TYPE_OF_TRAINGLE(len1, len2, len3);


        //***** QUESTION # 10 (REMAINING PART) *****


        Console.WriteLine("Enter the number of stars:");
        int star = int.Parse(Console.ReadLine());

        PATTERN_PRNTING(star);

        

        //***** QUESTION # 11 (REMAINING PART) *****


        Console.WriteLine("Enter the palindrome_number:");
        int palindrome_number = int.Parse(Console.ReadLine());

        CHECK_PALINDROME_NUMBER(palindrome_number);
    }
}