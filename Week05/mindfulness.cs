using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Mindfulness Activities ---");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an activity (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Run();
                        break;
                    case "2":
                        ReflectionActivity reflection = new ReflectionActivity();
                        reflection.Run();
                        break;
                    case "3":
                        ListingActivity listing = new ListingActivity();
                        listing.Run();
                        break;
                    case "4":
                        Console.WriteLine("\nThank you for taking time for mindfulness today.");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 4.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void PauseWithSpinner(int duration)
        {
            char[] chars = { '-', '\\', '|', '/' };
            DateTime startTime = DateTime.Now;
            int index = 0;
            while ((DateTime.Now - startTime).TotalSeconds < duration)
            {
                Console.Write($"\rPreparing {chars[index % chars.Length]}");
                Thread.Sleep(100);
                index++;
            }
            Console.Write("\rReady!        \n");
        }

        static void PauseWithCountdown(int duration)
        {
            for (int i = duration; i > 0; i--)
            {
                Console.Write($"\rStarting in {i}...");
                Thread.Sleep(1000);
            }
            Console.Write("\rGo!           \n");
        }
    }

    class Activity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        protected int Duration { get; set; }

        public Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void StartMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {Name} ---");
            Console.WriteLine(Description);
            while (true)
            {
                Console.Write("Enter the duration for this activity in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
                {
                    Duration = duration;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a positive integer for the duration.");
                }
            }
            Console.WriteLine("\nPrepare to begin...");
            Program.PauseWithSpinner(3);
        }

        public void EndMessage()
        {
            Console.WriteLine("\nWell done!");
            Program.PauseWithSpinner(2);
            Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
            Program.PauseWithSpinner(3);
        }

        public virtual void Run()
        {
            throw new NotImplementedException("Subclasses must implement the Run method.");
        }
    }

    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

        public override void Run()
        {
            StartMessage();
            int breathCycleDuration = 4; // Seconds for each inhale/exhale
            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                Console.WriteLine("\nBreathe in...");
                Program.PauseWithCountdown(breathCycleDuration);
                if ((DateTime.Now - startTime).TotalSeconds >= Duration)
                    break;
                Console.WriteLine("\nBreathe out...");
                Program.PauseWithCountdown(breathCycleDuration);
                if ((DateTime.Now - startTime).TotalSeconds >= Duration)
                    break;
            }
            EndMessage();
        }
    }

    class ReflectionActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

        public override void Run()
        {
            StartMessage();
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine($"\nConsider the following: {prompt}");
            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                string question = _questions[random.Next(_questions.Count)];
                Console.WriteLine($"\nReflect on: {question}");
                Program.PauseWithSpinner(5); // Time for reflection
                if ((DateTime.Now - startTime).TotalSeconds >= Duration)
                    break;
            }
            EndMessage();
        }
    }

    class ListingActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

        public override void Run()
        {
            StartMessage();
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine($"\nThink about: {prompt}");
            Program.PauseWithCountdown(5); // Time to prepare
            Console.WriteLine("\nStart listing items (press Enter after each item).");
            List<string> items = new List<string>();
            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
                if ((DateTime.Now - startTime).TotalSeconds >= Duration)
                    break;
            }
            Console.WriteLine($"\nYou listed {items.Count} items.");
            EndMessage();
        }
    }
}