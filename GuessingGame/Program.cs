using System;

string greeting = "Welcome to the Guessing Game! A game that tests YOUR guessing skills and my coding abilities (and patience)!";

Console.WriteLine(greeting);
GuessingGame();

void GuessingGame()
{
    Random random = new Random();
    int secretNumber = random.Next(1, 101);
    int maximumAttempts = 0;
    int attempts = 0;
    string keystroke = "Press ANY key to continue...";

    Console.WriteLine("Choose a difficulty level: Easy, Medium, Hard, Cheater");
    string difficulty = Console.ReadLine().Trim().ToLower();

    switch (difficulty)
    {
        case "easy":
            maximumAttempts = 8;
            break;
        case "medium":
            maximumAttempts = 6;
            break;
            break;
        case "hard":
            maximumAttempts = 4;
            break;
        case "cheater":
            maximumAttempts = int.MaxValue;
            break;
        default:
            Console.WriteLine("Invalid difficulty level. Defaulting to Medium.");
            maximumAttempts = 6;
            break;
    }

    while (attempts < maximumAttempts)
    {
        Console.WriteLine(@$"
GUESS {attempts + 1}/{maximumAttempts}: 

YOU'LL NEVER GUESS THIS RIGHT!
GO ON, TAKE A SHOT?");

        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int userGuess))
        {
            if (userGuess >= 1 && userGuess <= 100)
            {
                if (userGuess == secretNumber)
                {
                    Console.WriteLine("\nHOLY GUACAMOLE YOU GOT IT!");
                    return;
                }
                else
                {
                    if (userGuess < secretNumber)
                    {
                        Console.WriteLine("\nTOO LOW TOO SLOW...");
                    }
                    else
                    {
                        Console.WriteLine("\nYOU'RE SHOOTING TOO HIGH COWBOY!");
                    }

                    Console.WriteLine(keystroke);
                    Console.ReadKey(true);
                    attempts++;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Entry: Please enter a valid number between 1 and 100.");
                Console.WriteLine(keystroke);
                Console.ReadKey(true);
            }
        }
        else
        {
            Console.WriteLine("\nInvalid Entry: Please enter a valid number.");
            Console.WriteLine(keystroke);
            Console.ReadKey(true);
        }
    }

    Console.WriteLine($"\nSadly :( ... YOU are out of attempts! The correct number was {secretNumber}.");
}