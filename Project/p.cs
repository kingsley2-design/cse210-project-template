using System;
using System.Collections.Generic;
using System.Linq;

class Program
{                                                          
        }

        Console.WriteLine($"\nYour grade is: {letter}{sign}");
        Console.WriteLine(gradePercentage >= 70 ? "Congratulations! You passed the course. 🎉" : "Keep working hard! You'll do better next time. 💪");
    }

    static void GuessMyNumber()
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guess = -1, guessCount = 0;

            Console.WriteLine("\nWelcome to the Guess My Number game!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                if (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber) Console.WriteLine("Higher");
                else if (guess > magicNumber) Console.WriteLine("Lower");
                else Console.WriteLine($"You guessed it! 🎉 It took you {guessCount} tries.");
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower() == "yes";
        }

        Console.WriteLine("Thanks for playing! Goodbye. 👋");
    }

    static void ListOperations()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("\nEnter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }
            if (number == 0) break;
            numbers.Add(number);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered. Exiting program.");
            return;
        }

        int sum = numbers.Sum();
        double average = numbers.Average();
        int maxNumber = numbers.Max();
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        int smallestPositive = positiveNumbers.Count > 0 ? positiveNumbers.Min() : 0;

        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");
        if (positiveNumbers.Count > 0) Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        numbers.ForEach(num => Console.WriteLine(num));
    }

    static void NumberSquaring()
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome() => Console.WriteLine("\nWelcome to the program!");
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        while (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
        }
        return number;
    }
    static int SquareNumber(int number) => number * number;
    static void DisplayResult(string name, int squaredNumber) => Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
}