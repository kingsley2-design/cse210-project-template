import time
import random
import os

def clear_screen():
    """Clears the console screen."""
    os.system('cls' if os.name == 'nt' else 'clear')

def pause_with_spinner(duration):
    """Pauses for a given duration, showing a spinner animation."""
    chars = ['-', '\\', '|', '/']
    start_time = time.time()
    index = 0
    while time.time() - start_time < duration:
        print(f"\rPreparing {chars[index % len(chars)]}", end="", flush=True)
        time.sleep(0.1)
        index += 1
    print("\rReady!        ") # Clear the spinner

def pause_with_countdown(duration):
    """Pauses for a given duration, showing a countdown."""
    for i in range(duration, 0, -1):
        print(f"\rStarting in {i}...", end="", flush=True)
        time.sleep(1)
    print("\rGo!           ") # Clear the countdown

class Activity:
    """Base class for all mindfulness activities."""
    def __init__(self, name, description):
        self.name = name
        self.description = description
        self.duration = 0

    def start_message(self):
        """Displays the starting message and sets the duration."""
        clear_screen()
        print(f"--- {self.name} ---")
        print(self.description)
        while True:
            try:
                self.duration = int(input("Enter the duration for this activity in seconds: "))
                if self.duration > 0:
                    break
                else:
                    print("Please enter a positive duration.")
            except ValueError:
                print("Invalid input. Please enter a number.")
        print("\nPrepare to begin...")
        pause_with_spinner(3) # Standard preparation pause

    def end_message(self):
        """Displays the ending message."""
        print("\nWell done!")
        pause_with_spinner(2)
        print(f"You have completed the {self.name} activity for {self.duration} seconds.")
        pause_with_spinner(3)

    def run(self):
        """Abstract method to be implemented by derived classes."""
        raise NotImplementedError("Subclasses must implement the run method.")

class BreathingActivity(Activity):
    """Guides the user through a breathing exercise."""
    def __init__(self):
        super().__init__("Breathing Activity",
                         "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")

    def run(self):
        self.start_message()
        breath_cycle_duration = 4 # Seconds for each inhale/exhale
        start_time = time.time()
        while time.time() - start_time < self.duration:
            print("\nBreathe in...")
            pause_with_countdown(breath_cycle_duration)
            if time.time() - start_time >= self.duration:
                break
            print("\nBreathe out...")
            pause_with_countdown(breath_cycle_duration)
            if time.time() - start_time >= self.duration:
                break
        self.end_message()

class ReflectionActivity(Activity):
    """Prompts the user with reflection questions."""
    def __init__(self):
        super().__init__("Reflection Activity",
                         "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        self.prompts = [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ]
        self.questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ]

    def run(self):
        self.start_message()
        prompt = random.choice(self.prompts)
        print(f"\nConsider the following: {prompt}")
        start_time = time.time()
        while time.time() - start_time < self.duration:
            question = random.choice(self.questions)
            print(f"\nReflect on: {question}")
            pause_with_spinner(5) # Time for reflection
            if time.time() - start_time >= self.duration:
                break
        self.end_message()

class ListingActivity(Activity):
    """Guides the user to list items related to a prompt."""
    def __init__(self):
        super().__init__("Listing Activity",
                         "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        self.prompts = [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ]

    def run(self):
        self.start_message()
        prompt = random.choice(self.prompts)
        print(f"\nThink about: {prompt}")
        pause_with_countdown(5) # Time to prepare
        print("\nStart listing items (press Enter after each item).")
        items = []
        start_time = time.time()
        while time.time() - start_time < self.duration:
            item = input("> ")
            if item:
                items.append(item)
            else:
                print("Please enter an item.")
            if time.time() - start_time >= self.duration:
                break
        print(f"\nYou listed {len(items)} items.")
        self.end_message()

def main():
    """Main function to run the mindfulness app."""
    while True:
        clear_screen()
        print("--- Mindfulness Activities ---")
        print("1. Breathing Activity")
        print("2. Reflection Activity")
        print("3. Listing Activity")
        print("4. Exit")

        choice = input("Choose an activity (1-4): ")

        if choice == '1':
            breathing = BreathingActivity()
            breathing.run()
        elif choice == '2':
            reflection = ReflectionActivity()
            reflection.run()
        elif choice == '3':
            listing = ListingActivity()
            listing.run()
        elif choice == '4':
            print("\nThank you for taking time for mindfulness today.")
            break
        else:
            print("\nInvalid choice. Please enter a number between 1 and 4.")
            input("Press Enter to continue...")

if __name__ == "__main__":
    main()
    