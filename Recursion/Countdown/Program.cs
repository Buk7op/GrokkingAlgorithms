using System;

namespace Countdown
{
    class Program
    {
        static void Main(string[] args)
        {
            Countdown(3);
        }
        static void Countdown(int i)
        {
            Console.WriteLine(i + "...");
            if(i > 0)
            Countdown(i - 1);
        }
    }
}
