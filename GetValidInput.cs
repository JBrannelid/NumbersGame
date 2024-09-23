using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame
{   // GetValid input have 2 methods. Responsible to read user input, parse it to an integer and test if the integer is within valid range
    internal class GetValidInput
    {
        public static int TestUserGuess(int maxNumber)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    if (guess >= 1 && guess <= maxNumber)
                    {
                        return guess;
                    }
                    Console.WriteLine($"Vänligen skriv en siffra mellan 1-{maxNumber}");
                }
                else
                {
                    Console.WriteLine("Ogiltigt inmatning. Försök igen!");
                }
            }
        }
        public static int TestUserInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    return guess;
                }
                else
                {
                    Console.WriteLine("Ogiltigt inmatning. Försök igen!");
                }
            }
        }
    }
}