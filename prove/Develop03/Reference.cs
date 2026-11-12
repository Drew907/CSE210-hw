namespace Scripture;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public string GetString()
    {
        string reference = ($"{_book} {_chapter}:{_startVerse}-{_endVerse}");
      return reference;  
    } 
    public void SetString(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }



}