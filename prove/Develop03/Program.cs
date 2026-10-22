using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Collections.Generic;


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

class Program
{
    static void Main(string[] args)
    {
        Scripture S1 = new Scripture(("1 Nephi"),(3),(7),(7),("And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."));
        Scripture S2 = new Scripture(("2 Nephi"),(9),(28),(29),("O that cunning plan of the evil one! O the vainness, and the frailties, and the foolishness of men! When they are learned they think they are wise, and they hearken not unto the counsel of God, for they set it aside, supposing they know of themselves, wherefore, their wisdom is foolishness and it profiteth them not. And they shall perish.But to be learned is good if they hearken unto the counsels of God."));
        Scripture S3 = new Scripture(("Jacob"),(2),(18),(19),("But before ye seek for riches, seek ye for the kingdom of God. And after ye have obtained a hope in Christ ye shall obtain riches, if ye seek them; and ye will seek them for the intent to do good—to clothe the naked, and to feed the hungry, and to liberate the captive, and administer relief to the sick and the afflicted."));
        Scripture S4 = new Scripture(("Mosiah"),(4),(30),(30),("But this much I can tell you, that if ye do not watch yourselves, and your thoughts, and your words, and your deeds, and observe the commandments of God, and continue in the faith of what ye have heard concerning the coming of our Lord, even unto the end of your lives, ye must perish. And now, O man, remember, and perish not."));
        Scripture S5 = new Scripture(("Alma"),(37),(6),(7),("Now ye may suppose that this is foolishness in me; but behold I say unto you, that by small and simple things are great things brought to pass; and small means in many instances doth confound the wise.And the Lord God doth work by means to bring about his great and eternal purposes; and by very small means the Lord doth confound the wise and bringeth about the salvation of many souls."));
        Console.WriteLine("Develop03 Scripture memorizer tool by Drew Stephenson");
        Console.WriteLine("Choose a scripture to memorize type 1-5");
        Console.WriteLine("1. 1 Nephi 3:7");
        Console.WriteLine("2. 2 Nephi 9:28-29");
        Console.WriteLine("3. Jacob 2:18-19");
        Console.WriteLine("4. Mosiah 4:30");
        Console.WriteLine("5. Alma 37:6-7");
        string choice = Console.ReadLine();

        Scripture selectedScripture;
        switch (choice)
        {
            case "1":
                selectedScripture = S1;
                break;

            case "2":
                selectedScripture = S2;
                break;

            case "3":
                selectedScripture = S3;
                break;
            
            case "4":
                selectedScripture = S4;
                break;

            case "5":
                selectedScripture = S5;
                break;

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        bool running = true;

        while (running == true)
        {


        Console.Clear();
        Console.WriteLine("Develop03 Scripture memorizer tool by Drew Stephenson");
        Console.WriteLine();
        selectedScripture.Display();
        selectedScripture.HideRandomWords();
        
        Console.WriteLine();
        Console.WriteLine("Press enter to continue or type 'quit' to finish:");
        

        string choice2 = Console.ReadLine();
        if (choice2 == "quit")
        {
            running = false;
        }
        }
    }
}