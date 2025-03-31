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