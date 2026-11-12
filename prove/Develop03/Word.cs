namespace Scripture;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayString()
    {
        string returnword = _text;

        return returnword;
    }


    public bool GetHiddenBool()
    {
        
        return _isHidden;
    }
}