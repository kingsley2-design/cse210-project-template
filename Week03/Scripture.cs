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
