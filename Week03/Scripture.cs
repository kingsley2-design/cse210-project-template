using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Alma", 37, 6, 7), "Now ye may suppose that this is foolishness in me; but behold, I say unto you, that by small means the Lord can bring about great things.")
        };

        Random random = new Random();
        Scripture currentScripture = scriptures[random.Next(scriptures.Count)];

        while (!currentScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                return;
            }

            currentScripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine(currentScripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden.");
    }
}

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        List<Word> unhiddenWords = _words.Where(word => !word.IsHidden).ToList();

        if (unhiddenWords.Count == 0) return;

        int wordsToHide = Math.Min(3, unhiddenWords.Count); 
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(unhiddenWords.Count);
            unhiddenWords[index].Hide();
            unhiddenWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()} {_words.Aggregate("", (current, word) => current + word.GetDisplayText() + " ").Trim()}";
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden);
    }
}

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = startVerse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}

public class Word
{
    private string _text;
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        _text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string GetDisplayText()
    {
        if (IsHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}