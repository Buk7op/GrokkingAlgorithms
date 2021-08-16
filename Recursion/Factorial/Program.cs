using System;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
        }
        static int Factorial(int i)
        {
            if(i == 1) return 1;
            else return i * Factorial(i - 1);
        }
    }
}
