using System;
class Program
{

    static void Main()
    {
        Entry entry = new Entry("What is your favorite color?", "Blue");
        entry.Display();

        string fileLine = entry.ToFileFormat();
        Entry restoredEntry = Entry.FromFileFormat(fileLine);
        restoredEntry.Display();
    public class Entry

    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string Date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"[{Date}] {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Lenght < 3) throw new FormatException("invalid file format");
        return new Entry(parts[0], parts[1]) parts[2]};
    }
}