using System;

namespace Assignment_2_Arrays_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
Q#1 : Function TimeConvert(num) takes the num parameter being passed and return the number of hours and minutes the parameterconverts to
(i.e if return 63 then output should be 1:3) seperated by the colon.

int hours = num/ 60;
int minutes = num % 60;
return rrrh