// Programmer:   Johannes Brannelid
// Program:      Fullstack .NET 2024
// Course:       Programmering med C# och .NET
// Lab 3:        Gissa numret
using System;

namespace NumbersGame
{
    internal class Program
    {
        // Initialise inside the class Program so main and belongin functions can acess the veriabel
        private static int maxNumber = 20; // Default difficulty level - Easy level

        static void Main(string[] args)
        {
            bool endApp = false;
            string userInput;

            Console.WriteLine("Välkommen till spelet gissa nummer!\n");

            // Gameloop runt as long ass bool endApp = false
            while (!endApp)
            {
                PrintMenu();
                Console.WriteLine("");
                userInput = Console.ReadLine().ToUpper();

                Console.Clear();

                // Main user menu handler
                switch (userInput)
                {
                    case "A":
                        StartGame();
                        break;
                    case "B":
                        ShowSettings();
                        break;
                    case "C":
                        Console.WriteLine("Välkommen tillbaka!");
                        endApp = true;
                        break;
                    default:
                        Console.WriteLine("Fel inmatning, försök igen!\n");
                        break;
                }
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine("Meny");
            Console.WriteLine("[A]Starta ett nytt spel");
            Console.WriteLine("[B]Inställningar");
            Console.WriteLine("[C]Avsluta program");
        }
        static void StartGame()
        {
            // number call the class NumberGenerator witch generate a random number between 1 and maxNumber
            int number = NumberGenerator.NewRandomNumber(maxNumber);
            bool newGameLoop = true;
            int gameMaxAttempts = 5; // User max attempts
            int numberOfUserAttempts = 0;

            Console.WriteLine($"Jag tänker på ett nummer mellan 1-{maxNumber}. " +
                              $"Kan du gissa vilket? Du får {gameMaxAttempts} försök");

            while (newGameLoop)
            {
                Console.Write($"\nFörsök {numberOfUserAttempts + 1} av {gameMaxAttempts}: ");

                // Read user input and test it in a static class. The maxNumber is a changeable variable depending on the difficulty level or user input
                int userGuess = GetValidInput.TestUserGuess(maxNumber);
                numberOfUserAttempts++; // Multiplie user attempt with 1

                if (userGuess == number)
                {
                    Console.Clear();
                    if (gameMaxAttempts == numberOfUserAttempts)
                    {
                        Console.WriteLine($"Wohoo! Du klarade det på sista försöket!\n" +
                                          $"Det rätta numret var siffran: {number}\n" +
                                          $"\nTryck på en valfri tagent för att fortsätta....\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Wohoo! Du klarade det på försök {numberOfUserAttempts} av {gameMaxAttempts}!\n" +
                                          $"Det rätta numret var siffran: {number}\n" +
                                          $"\nTryck på en valfri tagent för att fortsätta....\n");
                        Console.ReadKey();
                    }
                    break;

                }

                if (userGuess < number)
                    if (userGuess == number - 2)
                    {
                        Console.WriteLine("Ajaj nu bränns det! Försök igen med ett något högre tal");
                    }
                    else if (userGuess >= number - 3)
                    {
                        Console.WriteLine("Det börjar att brännas. Försök med ett högre tal");
                    }
                    else if (userGuess >= number - 6)
                    {
                        Console.WriteLine("Din gisning var för låg");
                    }
                    else
                    {
                        Console.WriteLine("Oj vilken dålig gisning. Ditt nummer är alldeles för lågt");
                    }

                if (userGuess > number)
                {
                    if (userGuess == number + 2)
                    {
                        Console.WriteLine("Ajaj nu bränns det! Försök igen med ett något lägre tal");
                    }
                    else if (userGuess <= number + 3)
                    {
                        Console.WriteLine("Det börjar att brännas. Försök med ett lägre tal");
                    }
                    else if (userGuess <= number + 6)
                    {
                        Console.WriteLine("Din gisning var för hög");
                    }
                    else
                    {
                        Console.WriteLine("Oj vilken dålig gisning. Ditt nummer är alldeles för högt");
                    }
                }

                if (numberOfUserAttempts >= gameMaxAttempts)
                {
                    Console.Clear();
                    Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på {gameMaxAttempts} försök!\n" +
                                      $"Det rätta numret var siffran: {number}\n");
                    Console.WriteLine("Tryck på en valfri tagent för att fortsätta....\n");
                    Console.ReadKey();
                    newGameLoop = false;
                }
            }
            Console.Clear();
        }
        static void ShowSettings()
        {
            Console.WriteLine("Välj svårighetsgrad:");
            Console.WriteLine("[1] Lätt (1-20)");
            Console.WriteLine("[2] Medel (1-30)");
            Console.WriteLine("[3] Svår (1-60)");
            Console.WriteLine("[4] Välj valfri maxsiffra");
            Console.WriteLine("[5] Tillbaka till huvudmeny");
            Console.WriteLine();

            string choice = Console.ReadLine();

            // The switch loop change maxNumber base on the users choise
            switch (choice)
            {
                case "1":
                    maxNumber = 20;
                    Console.WriteLine("Du har valt Lätt\n");
                    break;
                case "2":
                    maxNumber = 30;
                    Console.WriteLine("Du har valt Medel\n");
                    break;
                case "3":
                    maxNumber = 60;
                    Console.WriteLine("Du har valt Svår\n");
                    break;
                case "4":
                    Console.WriteLine("Hur många tal ska det finnas att gissa på?");
                    int userChoice = GetValidInput.TestUserInput();
                    maxNumber = userChoice;
                    break;
                case "5":
                    Console.WriteLine("Tillbaka till huvudmenyn\n");
                    break;
                default:
                    Console.WriteLine("Felaktigt val. Försök igen\n");
                    break;
            }
        }
    }
}