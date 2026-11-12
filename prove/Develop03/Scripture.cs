namespace Scripture;
public class Scripture
{
    private List<Word> _words = new List<Word>();

    private Reference _reference; 



// takes in scripture and info and splits it into indevidual objects for words and reference
    public Scripture(string book, int chapter,int startVerse, int endVerse,string text)
    {
        _reference = new Reference();
        _reference.SetString(book, chapter, startVerse, endVerse);

        string[] words = text.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }
    public void Display()
    {
        string display = _reference.GetString() + " ";

        foreach (Word word in _words)
        {

            bool isHidden = word.GetHiddenBool();

            if (isHidden == false)
            {
            display += word.GetDisplayString() + " ";
            }
            else
            {            
                display += "___ ";
            }           
        }
        Console.WriteLine(display.Trim());
    }
    public void HideRandomWords()
        {
            Random random = new Random();

            foreach (Word word in _words)
            {
                bool hide = random.Next(5) == 0;

                if (hide)
                {
                    word.Hide();
                }
            }
        }

        


}