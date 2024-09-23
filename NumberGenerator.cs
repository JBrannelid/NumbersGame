using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGame
{
    static class NumberGenerator // New static class
    {
        private static readonly Random random = new(); // Readonly Random instance, it can only be assigned once

        public static int NewRandomNumber(int _maxNumber) //Ask for arugment _maxNumber 
        {
            return random.Next(1, _maxNumber + 1); // Generates and return a random number between 1 and _maxNumber
        }
    }
}
